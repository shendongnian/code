    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    namespace TaskTest
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var demo = new Program();
                demo.SimulateClick();
                Console.ReadLine();
            }
    
            public void SimulateClick()
            {
                buttonStart_Click(null, null);
            }
    
            private async void buttonStart_Click(object sender, EventArgs e)
            {
                var tasks = new List<Task>();
                for (var i = 0; i < 36; i++)
                {
                    var taskId = i;
                    var t = Task.Factory.StartNew((() =>
                    {
                        Console.WriteLine($"Starting Task ({taskId})");
                        for (var ii = 0; ii < 200000; ii++)
                        {
                            Task.Delay(TimeSpan.FromMilliseconds(500)).Wait();
                            var s1 = new string(' ', taskId);
                            var s2 = new string(' ', 36-taskId);
                            Console.WriteLine($"Updating Task {s1}X{s2} ({taskId})");
                        }
                        Console.Write($"Done ({taskId})");
                    }),TaskCreationOptions.LongRunning);
                    tasks.Add(t);
                }
                await Task.WhenAll(tasks);
                Console.WriteLine("Done, enabld UI controls");
            }
        }
    }
