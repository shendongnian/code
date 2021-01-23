        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            var mmf = MemoryMappedFile.CreateFromFile(@"f:\test.bin");
            var stream = mmf.CreateViewStream();
            for (int i = 0; i < 100000; i++)
            {
                stream.ReadByte();
            }
            Console.WriteLine(sw.Elapsed);
        }
