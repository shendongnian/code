    using System;
    using System.Diagnostics;
    using System.Text;
    class Program
    {
        static string Method1()
        {
            StringBuilder builder = new StringBuilder();
            foreach (string value in _array)
                builder.Append(value);
            return builder.ToString();
        }
        static StringBuilder _builder = new StringBuilder();
        static string Method2()
        {
            StringBuilder builder = _builder;
            builder.Clear();
            foreach (string value in _array)
                builder.Append(value);
            return builder.ToString();
        }
        static string[] _array = { "dot", "net", "perls", "string", "array" };
        const int _max = 1000000;
        static void Main()
        {
            Method1();
            Method2();
            // Version 1: use new StringBuilder each time.
            var s1 = Stopwatch.StartNew();
            for (int i = 0; i < _max; i++)
            {
                Method1();
            }
            s1.Stop();
            // Version 2: reuse a single StringBuilder instance.
            var s2 = Stopwatch.StartNew();
            for (int i = 0; i < _max; i++)
            {
                Method2();
            }
            s2.Stop();
            Console.WriteLine(s1.Elapsed.TotalMilliseconds);
            Console.WriteLine(s2.Elapsed.TotalMilliseconds);
            Console.Read();
        }
    }
