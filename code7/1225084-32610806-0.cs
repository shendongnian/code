    using System;
    using System.Linq;
    namespace Demo
    {
        internal class Program
        {
            private static void Main()
            {
                int n = int.Parse(Console.ReadLine());
                int[] arr = Console.ReadLine().Split(' ').Take(n).Select(int.Parse).ToArray();
                int sum = arr.Sum();
                Console.WriteLine("{0}", sum);
            }
        }
    }
