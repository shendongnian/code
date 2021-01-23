    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        public class Demo
        {
            public string Key;
            public string S1;
            public string S2;
            public override string ToString()
            {
                return string.Format("Key: {0}, S1: {1}, S2: {2}", Key, S1, S2);
            }
        }
        static class Program
        {
            static void Main()
            {
                var list = new List<Demo>
                {
                    new Demo {Key = "Z", S1 = "Z1", S2 = "Z2"},
                    new Demo {Key = "Y", S1 = "Y1", S2 = "Y2"},
                    new Demo {Key = "X", S1 = "X1", S2 = "X2"},
                    new Demo {Key = "W", S1 = "W1", S2 = "W2"},
                    new Demo {Key = "V", S1 = "V1", S2 = "V2"}
                };
                // Rather than write your own IComparer<Demo> implementation, you can
                // leverage a built-in .Net implementation by using 
                // Comparer<Demo>.Create() as follows:
                var keyComparer = Comparer<Demo>.Create((x, y) => string.Compare(x.Key, y.Key, StringComparison.Ordinal));
                QuicksortSTRING(list, 0, list.Count-1, keyComparer);
                Console.WriteLine(string.Join("\n", list));
            }
            public static void QuicksortSTRING<T>(IList<T> elements, int left, int right, IComparer<T> comparer)
            {
                int i = left, j = right;
                var pivot = elements[(left + right)/2];
                while (i <= j)
                {
                    while (comparer.Compare(elements[i], pivot) < 0)
                    {
                        i++;
                    }
                    while (comparer.Compare(elements[j], pivot) > 0)
                    {
                        j--;
                    }
                    if (i <= j)
                    {
                        // Swap
                        T tmp = elements[i];
                        elements[i] = elements[j];
                        elements[j] = tmp;
                        i++;
                        j--;
                    }
                }
                // Recursive calls
                if (left < j)
                {
                    QuicksortSTRING(elements, left, j, comparer);
                }
                if (i < right)
                {
                    QuicksortSTRING(elements, i, right, comparer);
                }
            }
        }
    }
