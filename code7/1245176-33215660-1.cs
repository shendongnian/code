        static void Main(string[] args)
        {
            Task t = new Task(() => { Console.ReadLine(); Console.WriteLine("You pressed enter"); });
            t.Start();
            Thread.Sleep(5000);
        }
