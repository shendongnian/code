        static void Main(string[] args)
        {
            var x = new RandomNumbers(10, 0, 500);
            x.Timestamp().Subscribe(i => Console.WriteLine("First sub: {0} {1}", i.Timestamp.DateTime.ToString("O"), i.Value));
            Thread.Sleep(1000);
            x.Timestamp().Subscribe(i => Console.WriteLine("Second sub: {0} {1}", i.Timestamp.DateTime.ToString("O"), i.Value));
            Console.Read();
        }
