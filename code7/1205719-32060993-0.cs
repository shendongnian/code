    using System;
    class Test
    {
        static void Main()
        {
            string[] temp = Console.ReadLine().Split();
            int[] numbers = new int[temp.Length];
            for (var i = 0; i < numbers.Length; i++)
                 numbers[i] = int.Parse(temp[i]);
            int minIndex = 0;
            int maxIndex = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < numbers[minIndex])
                    minIndex = i;
                if (numbers[i] > numbers[maxIndex])
                    maxIndex = i;
            }
        
            Swap(ref numbers[maxIndex], ref numbers[0]);
            Swap(ref numbers[minIndex], ref numbers[numbers.Length - 1]);
            Print(numbers, ConsoleColor.Green, ConsoleColor.Red);
            Swap(ref numbers[0], ref numbers[numbers.Length - 1]);
            Print(numbers, ConsoleColor.Red, ConsoleColor.Green);
        }
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static void Print(int[] array, ConsoleColor a, ConsoleColor b)
        {
            Console.ForegroundColor = a;
            Console.Write(array[0] + "  ");
            Console.ResetColor();
            for (int i = 1; i < array.Length - 1; i++)
                Console.Write(array[i] + "  ");
            Console.ForegroundColor = b;
            Console.WriteLine(array[array.Length - 1]);
            Console.ResetColor();
        }
    }
