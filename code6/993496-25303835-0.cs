    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        internal static class Program
        {
            static void Main()
            {
                string[] a = {"A", "B", "C", "D"};
                int[]    b = { 1, 2 };
                char[]   c = {'X', 'Y', 'Z'};
                double[] d = {-0.1, -0.2, -0.3};
                var sequences = new [] { a, b.Cast<object>(), c.Cast<object>(), d.Cast<object>() };
                Console.WriteLine(string.Join("\n", Combine("", sequences)));
            }
            public static IEnumerable<string> Combine(string prefix, IEnumerable<IEnumerable<object>> sequences)
            {
                foreach (var item in sequences.First())
                {
                    string current = (prefix == "") ? item.ToString() : prefix + "_" + item;
                    var remaining = sequences.Skip(1);
                    if (!remaining.Any())
                    {
                        yield return current;
                    }
                    else
                    {
                        foreach (var s in Combine(current, remaining))
                            yield return s;
                    }
                }
            }
        }
    }
                                            
