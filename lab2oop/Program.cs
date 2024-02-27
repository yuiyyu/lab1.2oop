using System;

namespace ArrayFilter
{
    class Program
    {
        delegate bool FilterDelegate(int x, int k);
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть ціле число k:");
            int k = int.Parse(Console.ReadLine());
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            FilterDelegate filterDelegate = delegatDLFilt;
            int[] filteredArray1 = methodWhere(array, filterDelegate, k);
            int[] filteredArray2 = methodImplementation(array, filterDelegate, k);
            Console.WriteLine("Результат за допомогою методу Where:");
            PrintArray(filteredArray1);
            Console.WriteLine("Результат з власною реалізацією:");
            PrintArray(filteredArray2);
        }
        static bool delegatDLFilt(int x, int k)
        {
            return x % k == 0; 
        }
        static int[] methodWhere(int[] array, FilterDelegate filterDelegate, int k)
        {
            return Array.FindAll(array, x => filterDelegate(x, k));
        }
        static int[] methodImplementation(int[] array, FilterDelegate filterDelegate, int k)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (filterDelegate(array[i], k))
                {
                    count++;
                }
            }
            int[] filteredArray = new int[count];
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (filterDelegate(array[i], k))
                {
                    filteredArray[index] = array[i];
                    index++;
                }
            }
            return filteredArray;
           
        }
        static void PrintArray(int[] array)
        {
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
