    const int CHUNK_SIZE = 1024;
    using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
    {
        using (BinaryReader reader = new BinaryReader(stream, new ASCIIEncoding()))
        {
            byte[] chunk;
            chunk = reader.ReadBytes(CHUNK_SIZE);
            while (chunk.Length > 0)
            {
                DumpBytes(chunk, chunk.Length);
                chunk = reader.ReadBytes(CHUNK_SIZE);
            }
        }
    }
