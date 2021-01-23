        static void Main(string[] args)
        {
            Console.WriteLine("Hot 1");
            var hotSource = HotSource();
            Process(hotSource);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Hot 2");
            Process(hotSource);
            Console.ReadLine();
        }
