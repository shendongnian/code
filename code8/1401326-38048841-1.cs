        static void Main(string[] args)
        {
            Console.WriteLine("Started");
            Task.WaitAll(task1(), task2());
            Console.WriteLine("Ended");
        }
        static async Task<string> task1()
        {
            Console.WriteLine("Started task1");
            var task = await Task.Run(() => { return "task1"; });
            Console.WriteLine("Ended task1");
            return task;
        }
        static async Task<string> task2()
        {
            Console.WriteLine("Started task2");
            var task = await Task.Run(() => { return "task2"; });
            Console.WriteLine("Ended task2");
            return task;
        }
    }
