    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var input = new string[] {
                    "S1", 
                    "R1", 
                    "R2", 
                    "S2",
                    "S3"
                };
                foreach (var item in CombinationsOfSAndR(input)) 
                {
                    Console.WriteLine("{0} -> {1}", item.Key, item.Value);
                }
                /* OUT:
                S1 -> R1
                S1 -> R2
                S2 -> R1
                S2 -> R2
                S3 -> R1
                S3 -> R2 */
            }
            static IEnumerable<KeyValuePair<string, string>> CombinationsOfSAndR(string[] input)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i].StartsWith("S"))
                    {
                        for (int j = 0; j < input.Length; j++)
                        {
                            if (input[j].StartsWith("R"))
                            {
                                yield return new KeyValuePair<string, string>(input[i], input[j]);
                            }
                        }
                    }
                }
            }
        }
    }
