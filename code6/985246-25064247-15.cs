    static bool CheckForEquality(object a, object b)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (MemoryStream streamA = new MemoryStream())
        using (MemoryStream streamB = new MemoryStream())
        {
            formatter.Serialize(streamA, a);
            formatter.Serialize(streamB, b);
            if (streamA.Length != streamB.Length)
                return false;
            streamA.Seek(0, SeekOrigin.Begin);
            streamB.Seek(0, SeekOrigin.Begin);
            for (int value = 0; (value = streamA.ReadByte()) >= 0; )
            {
                if (value != streamB.ReadByte())
                    return false;
            }
                
            return true;
        }
    }
