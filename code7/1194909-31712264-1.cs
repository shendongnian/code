    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using extended;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                IEnumerable<int> cities = new[] { 1, 2, 3, 4, 5 };
                IEnumerable<int> query = cities.StartsWith(hello);
                foreach (var item in query)
                {
                    Console.WriteLine(item);
                }
                Console.ReadKey();
            }
            static int hello(int x)
            {
            return x > 4 ? x : 0;
            }
        }
    }
    namespace extended
    {
        public static class A
        {
            public static IEnumerable<T> StartsWith<T>(this IEnumerable<T> input, inputdelegate<T> predicate)
            {
                foreach (var item in input)
                {
                    if (item.Equals(predicate(item)))
                    {
                        yield return item;
                    }
                }
            }
            public delegate T inputdelegate<T>(T input);
        }
    }
