    using System;
    using System.IO;
    namespace Progaram
    {
        class Count
        {
            static void Main()
            {
                string[] numbers = File.ReadAllLines("file.txt");
        
                int summary = 0;
    
                for (int i = 0; i < numbers.Length; i++)
                {
                    summary += Convert.ToInt32(numbers[i]);
                }
    
                Console.WriteLine(summary);    
            }
        }
    }
