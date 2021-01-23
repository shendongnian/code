        Stream f = File.OpenRead(fileName);
        BinaryReader br = new BinaryReader(f);
        for (int i = 0; i < f.Length - 10; i++)
        {
            f.Seek(i, SeekOrigin.Begin);
            if (br.ReadUInt32() == 0xa00003)
            {
                Console.WriteLine("Found @ {0}", i);
            }
        }
        br.Close();
