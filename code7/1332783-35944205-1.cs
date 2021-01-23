    using System;
    using System.IO;
    namespace Progaram
    {
        class Count
        {
            static void Main()
            {
    
                using (StreamReader sr = new StreamReader("file.txt"))
                {
    
                    string[] numbers = File.ReadAllLines("file.txt");
    
    
                    int summary = 0;
    
                    for (int i = 0; i < numbers.Length; i++)
                    {
    
                        summary += Convert.ToInt32(numbers[i]);
    
                        //Console.WriteLine(numbers[i]);
                    }
    
                    Console.WriteLine(summary);
    
                    sr.ReadLine();
                }
            }
        }
    }
