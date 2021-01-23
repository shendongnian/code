    using System;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                var numbers = Enumerable.Range(1, 20).ToList();
                var rng = new Random();
                for (int i = 0; i < numbers.Count; ++i)
                {
                    if (rng.NextDouble() >= 0.5) // If "someCircumstances"
                    {
                        numbers.Add(numbers[i]*2);
                    }
                    else
                    {
                        // Assume here you have some way to determine the 
                        // index of the item to remove. 
                        // For demo purposes, I'll just calculate a random index.
                        int index = rng.Next(0, numbers.Count);
                        if (index >= i)
                            --i;
                        numbers.RemoveAt(index);
                    }
                }
                Console.WriteLine(string.Join("\n", numbers));
            }
        }
    }
