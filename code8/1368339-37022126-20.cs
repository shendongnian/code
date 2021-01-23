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
                    PropertiesGetterStringWithoutThenWithReflection();
                    PropertiesGetterStringWithThenWithoutReflection();
                }
            }
            public static void PropertiesGetterStringWithoutThenWithReflection()
            {
                Console.WriteLine("PropertiesGetterStringWithoutThenWithReflection()");
                int count = 100000;
                var bar = new Bar
                {
                    Id = 42,
                    Number = "42",
                };
                var props = bar.GetType().GetProperties();
                string concat1 = "";
                string concat2 = "";
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < count; i++)
                {
                    concat2 += bar.Number;
                }
                sw.Stop();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                long milliseconds = sw.ElapsedMilliseconds;
                sw.Restart();
                for (int i = 0; i < count; i++)
                {
                    concat1 += (string)props[1].GetValue(bar);
                }
                sw.Stop();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                long millisecondsReflection = sw.ElapsedMilliseconds;
                Console.WriteLine("Without reflection: " + milliseconds);
                Console.WriteLine("With reflection: " + millisecondsReflection);
            }
            public static void PropertiesGetterStringWithThenWithoutReflection()
            {
                Console.WriteLine("PropertiesGetterStringWithThenWithoutReflection()");
                int count = 100000;
                var bar = new Bar
                {
                    Id = 42,
                    Number = "42",
                };
                var props = bar.GetType().GetProperties();
                string concat1 = "";
                string concat2 = "";
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < count; i++)
                {
                    concat1 += (string)props[1].GetValue(bar);
                }
                sw.Stop();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                long millisecondsReflection = sw.ElapsedMilliseconds;
                sw.Restart();
                for (int i = 0; i < count; i++)
                {
                    concat2 += bar.Number;
                }
                sw.Stop();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                long milliseconds = sw.ElapsedMilliseconds;
                Console.WriteLine("Without reflection: " + milliseconds);
                Console.WriteLine("With reflection: " + millisecondsReflection);
            }
        }
    }
