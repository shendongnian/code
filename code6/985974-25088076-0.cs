        static void Main(string[] args)
        {
            using (MemoryMappedFile mmf = MemoryMappedFile.CreateNew("testmap", 10000))
            {
                int i = 0;
                using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        while (i++ < 10000)
                        {
                            writer.Write(i);
                            Thread.Sleep(50);
                            writer.Seek(0, SeekOrigin.Begin);
                        }
                    }
                }
                Console.WriteLine("Done");
                Console.ReadLine();
            }
        }
