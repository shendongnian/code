    public static List<string> SplitIntoChunks(this string toSplit, int chunkSize)
    {
        int stringLength = toSplit.Length;
        int chunksRequired = (int)Math.Ceiling(decimal)stringLength / (decimal)chunkSize);
        List<string> chunks = new List<string>();
        int lengthRemaining = stringLength;
        for (int i = 0; i < chunksRequired; i++)
        {
            int lengthToUse = Math.Min(lengthRemaining, chunkSize);
            int startIndex = chunkSize * i;
            chunks.Add(toSplit.Substring(startIndex, lengthToUse));
            lengthRemaining = lenghtRemaining - lengthToUse;
        }
        return chunks;
    }
