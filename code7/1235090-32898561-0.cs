    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class Colors : IEnumerable, IEnumerator
    {
        private readonly string[] cols = new[] { "Red", "White", "Blue", "Yellow" };
        public IEnumerator GetEnumerator()
        {
            return cols.GetEnumerator();
        }
    }
    public class Colors2
    {
        private readonly string[] cols = new[] { "Red", "White", "Blue", "Yellow" };
        public IEnumerable<string> Colors
        {
            get { return cols; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Test2();
            Test3();
        }
        private static void Test()
        {
            var colors = new Colors();
            foreach (var c in colors)
            {
                // c is of type Object here because it's IEnumerable.
                Console.WriteLine(c);
            }
        }
        private static void Test2()
        {
            var colors2 = new Colors2();
            foreach (var c in colors2.Colors)
            {
                // c is of type String here because it's IEnumerable<string>.
                Console.WriteLine(c);
            }
        }
        private static void Test3()
        {
            foreach (var c in new[] { "Red", "White", "Blue", "Yellow" })
            {
                // c is of type String here.
                Console.WriteLine(c);
            }
        }
    }
