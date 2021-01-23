    using System;
    using System.ComponentModel;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                var worker = new BackgroundWorker();
                worker.DoWork += (sender, args) => ((Action) args.Argument)();
                worker.RunWorkerAsync(new Action(() => test("My String", 12345)));
                Console.ReadLine();
            }
            static void test(string s, int i)
            {
                Console.WriteLine("String = {0}, Int = {1}", s, i);
            }
        }
    }
