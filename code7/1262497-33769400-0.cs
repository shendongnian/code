    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () => { 
                List<Task> tasks = new List<Task>();
                for (int i = 0; i < 10; i++)
                {
                    int x = i; // closure
                    tasks.Add(Task.Factory.StartNew(() => Console.WriteLine(x.ToString())));
                }
                await Task.WhenAll(tasks.ToArray());
                
            });
            Console.ReadKey();
        }
    }
