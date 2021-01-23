    public const int CHUNK_SIZE = 30000;
    while (SB.Length > CHUNK_SIZE)
    {
        sw.Write(SB.ToString(0, CHUNK_SIZE));
        SB.Remove(0, CHUNK_SIZE);
    }
    sw.Write(SB);
