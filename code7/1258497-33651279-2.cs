    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    namespace Demo
    {
        class Program
        {
            public static void Main()
            {
                int count = 1000000;
                object obj = new object();
                var keys   = new string[count];
                var values = new object[count];
                for (int i = 0; i < count; ++i)
                {
                    keys[i] = randomString(5, 16);
                    values[i] = obj;
                }
                // Sort key array and value arrays in tandem to keep the relation between keys and values.
                Array.Sort(keys, values, 0, keys.Length);
                // Now you can use StartsWith() to return the indices of strings in keys[]
                // that start with a specific string. The indices can be used to look up the
                // corresponding values in values[].
                Console.WriteLine("Count of ZZ = " + StartsWith(keys, "ZZ").Count());
                // Test a load of times with 1000 random prefixes.
                var prefixes = new string[1000];
                for (int i = 0; i < 1000; ++i)
                    prefixes[i] = randomString(1, 8);
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < 1000; ++i)
                    for (int j = 0; j < 1000; ++j)
                        StartsWith(keys, prefixes[j]).Any();
                Console.WriteLine("1,000,000 checks took {0} for {1} ms each.", sw.Elapsed, sw.ElapsedMilliseconds/1000000.0);
            }
            public static IEnumerable<int> StartsWith(string[] array, string prefix)
            {
                int index = Array.BinarySearch(array, prefix);
                if (index < 0)
                    index = ~index;
                // We might have landed partway through a set of matches, so find the first match.
                if (index < array.Length)
                    while ((index > 0) && array[index-1].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                        --index;
                while ((index < array.Length) && array[index].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    yield return index++;
            }
            static string randomString(int minLength, int maxLength)
            {
                int length = rng.Next(minLength, maxLength);
                const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                return new string(Enumerable.Repeat(CHARS, length)
                  .Select(s => s[rng.Next(s.Length)]).ToArray());
            }
            static readonly Random rng = new Random(12345);
        }
    }
