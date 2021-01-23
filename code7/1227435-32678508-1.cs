        static void Main(string[] args)
        {
            WriteMilionLines();
        }
        static void WriteMilionLines()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
               Console.WriteLine(i);
            }
            sw.Stop();
            string message = "ElapsedMilliseconds" + sw.ElapsedMilliseconds;
            File.WriteAllText(@"c:\log.txt", message);
        }
