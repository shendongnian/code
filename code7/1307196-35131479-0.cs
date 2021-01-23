    using System;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                var numbers = Enumerable.Range(1, 20).ToList();
                Random rng = new Random();
                for (int i = 0;  i < numbers.Count; ++i)
                {
                    if (rng.NextDouble() >= 0.5) // If "someCircumstances"
                    {
                        numbers.Add(numbers[i]*2);
                    }
                    else
                    {
                        numbers.RemoveAt(i--);
                    }
                }
                Console.WriteLine(string.Join("\n", numbers));
            }
        }
    }
