    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ArrayRepeat
    {
        public static class ArrayHelper
        {
            public static IEnumerable<T> Repeater<T>(this T[] a, int reps)
            {
                for (int i = 0; i < reps; i++)
                {
                    foreach (var item in a)
                    {
                        yield return item;
                    }
                }
            }
            public static T[] ArrayRepeat<T>(this T[] a, int reps)
            {
                return a.Repeater<T>(reps).ToArray();
            }
        }
        class Program
        {
        
            static void Main(string[] args)
            {
                string[] a = { "1", "2", "3", "4", "5" };
                string[] newArray = a.ArrayRepeat(3);
                var pressKeyToExit = Console.ReadKey();
            }
        }
    }
