    using System;
    using System.Diagnostics;
    namespace Demo
    {
        class Bar
        {
            public int Id { get; set; }
            public string Number { get; set; }
        }
        static class Program
        {
            static void Main()
            {
                for (int trial = 1; trial <= 5; ++trial)
                {
                    Console.WriteLine("Trial " + trial);
                    PropertiesGetterString();
                }
            }
            public static void PropertiesGetterString()
            {
                int count = 10000000;
                var bar = new Bar
                {
                    Id = 42,
                    Number = "42",
                };
                int totalLength = 0;
                var props = bar.GetType().GetProperties();
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < count; i++)
                {
                    totalLength += ((string)props[1].GetValue(bar)).Length;
                }
                sw.Stop();
                long millisecondsReflection = sw.ElapsedMilliseconds;
                Console.WriteLine("Length = " + totalLength);
                sw.Reset();
                totalLength = 0;
                sw.Start();
                for (int i = 0; i < count; i++)
                {
                    totalLength += bar.Number.Length;
                }
                sw.Stop();
                long milliseconds = sw.ElapsedMilliseconds;
                Console.WriteLine("Length = " + totalLength);
                Console.WriteLine("Without reflection: " + milliseconds);
                Console.WriteLine("With reflection: " + millisecondsReflection);
            }
        }
    }
