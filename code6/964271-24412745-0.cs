        static void Main(string[] args)
        {
            MemoryStream ms = new MemoryStream();
            StreamReader sr = new StreamReader(ms);
            StreamWriter sw = new StreamWriter(ms);
            Console.SetIn(sr);
            sw.WriteLine("Hi all!");
            ms.Seek(0, SeekOrigin.Begin);
            string line = Console.ReadLine();
            Console.WriteLine(line);
        }
