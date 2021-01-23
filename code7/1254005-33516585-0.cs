    class Program
    {
        static void Main(string[] args)
        {
            string[] wave = { "-", "/", "|", "\\" };
            animateLine(wave, 50, 10, Console.CursorLeft, Console.CursorTop);
            lock (_lock)
            {
                Console.Write(" \n");
            }
            animateLine(wave, 50, 10, Console.CursorLeft, Console.CursorTop);
            Console.Read();
        }
        private static readonly object _lock = new object();
        static void animateLine(string[] an, int i, int sec, int x, int y)
        {
            Thread thread = new Thread(delegate()
            {
                Console.Write("  ");
                Console.Write("\b");
                sec = sec * 1000;
                var time = Stopwatch.StartNew();
                while (time.ElapsedMilliseconds < sec)
                {
                    foreach (string val in an)
                    {
                        lock (_lock)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(val);
                        }
                        Thread.Sleep(i);
                    }
                }
                
                lock(_lock)
                {
                    Console.SetCursorPosition(x, y);
                    foreach (char cal in an.GetValue(0).ToString())
                    {
                        Console.Write(" ");
                    }
                    foreach (char cal in an.GetValue(0).ToString())
                    {
                        Console.Write("\b");
                    }
                    Console.Write(" \b");
                }
                time.Stop();
                time.Reset();
            });
            thread.IsBackground = true;
            thread.Start();
        }
    }
