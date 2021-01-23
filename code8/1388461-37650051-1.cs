    class Program
    {
        static object locker = new object();
        static List<char> buffer = new List<char>();
        static void Main(string[] args)
        {
            new Thread(Chat).Start("John");
            string ourName = "Mike";
            buffer.AddRange(ourName + ": ");
            Console.Write(new string(buffer.ToArray()));
            while (true)
            {
                var k = Console.ReadKey();
                if (k.Key == ConsoleKey.Enter && buffer.Count > 0)
                {
                    lock (locker)
                    {
                        Console.WriteLine();
                        buffer.Clear();
                        buffer.AddRange(ourName + ": ");
                        Console.Write(buffer.ToArray());
                    }
                }
                else
                {
                    buffer.Add(k.KeyChar);
                }
            }
        }
        static Random rnd = new Random();
        static void Chat(object name)
        {
            var dlg = new[] { "Hello", "How are you", "I'm all right", "What a weather" };
            while (true)
            {
                Thread.Sleep(3000 + rnd.Next(5000));
                lock (locker)
                {
                    Console.Write(new string('\b', buffer.Count));
                    var msg = name + ": " + dlg[rnd.Next(dlg.Length)];
                    var excess = buffer.Count - msg.Length;
                    if (excess > 0) msg += new string(' ', buffer.Count - msg.Length);
                    Console.WriteLine(msg);
                    Console.Write(new string(buffer.ToArray()));
                }
            }
        }
    }
