        static void Main(string[] args)
        {
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("testmap"))
                {
                    using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                    {
                        using (BinaryReader reader = new BinaryReader(stream))
                        {
                            int value = 0;
                            while (value != 10000)
                            {
                                value = reader.ReadInt32();
                                Console.WriteLine("Process A says: {0}", value);
                                stream.Seek(0L, SeekOrigin.Begin);
                                Thread.Sleep(20);
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Memory-mapped file does not exist. Run Process A first.");
            }
        }
