        static long position = 0;
        static void Main(string[] args)
        {
            var timer = new Timer(128);
            timer.Elapsed += Process;
            timer.AutoReset = false;
            timer.Start();
            Console.ReadLine();
        }
        private static void Process(object sender, ElapsedEventArgs e)
        {            
            using (var fs = new FileStream("input.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                fs.Seek(position, SeekOrigin.Begin);
                using (var fr = new StreamReader(fs))
                {
                    while (!fr.EndOfStream)
                    {
                        Console.WriteLine(fr.ReadLine());
                    }
                    position = fs.Position;
                }
            }
            (sender as Timer).Start();
        }
