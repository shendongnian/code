    public const int CHUNK_STRING_LENGTH = 30000;
    while (SB.Length > CHUNK_STRING_LENGTH )
    {
        sw.Write(SB.ToString(0, CHUNK_STRING_LENGTH ));
        SB.Remove(0, CHUNK_STRING_LENGTH );
    }
    sw.Write(SB);
