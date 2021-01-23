    using System;
    namespace Stackoverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] values = { 1, 19, 50 };
                int[] arr = new int[108];
                foreach (var val in values)
                {
                    int pos = val - 1;
                    while (arr[pos] != val)
                    {
                        arr[pos] = val;
                        pos += 20;
                        pos %= 108;
                    }
                }
                int sum = 0;
                int zeros = 0;
                for (int i = 0; i < 20; i++)
                {
                    if (arr[i] == 0) zeros++;
                    sum += arr[i];
                }
                Console.WriteLine((1000 - sum) / zeros);
            }
        }
    }
 
