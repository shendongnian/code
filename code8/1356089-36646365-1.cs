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
                QuicksortSTRING(list, 0, list.Count-1, demo => demo.Key);
                Console.WriteLine(string.Join("\n", list));
            }
            public static void QuicksortSTRING<T>(IList<T> elements, int left, int right, Func<T, IComparable> keySelector)
            {
                int i = left, j = right;
                var pivot = keySelector(elements[(left + right)/2]);
                while (i <= j)
                {
                    while (keySelector(elements[i]).CompareTo(pivot) < 0)
                    {
                        i++;
                    }
                    while (keySelector(elements[j]).CompareTo(pivot) > 0)
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
                    QuicksortSTRING(elements, left, j, keySelector);
                }
                if (i < right)
                {
                    QuicksortSTRING(elements, i, right, keySelector);
                }
            }
        }
    }
