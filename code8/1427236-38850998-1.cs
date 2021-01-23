    static void Main(string[] args)
    {
        Action a = new Action(() =>
        {
            using (RFIDReader scanner = new RFIDReader())
            {
                scanner.StartStreaming();
                while (true)
                {
                    foreach (string s in scanner.GetData(0))
                    {
                        WriteLine($"antenna0: {s}");
                    }
                    Thread.Sleep(1000);
                }
            }
        });
        Task t = Task.Factory.StartNew(a);
        t.Wait();
    }
