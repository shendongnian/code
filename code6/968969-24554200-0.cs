    // invent some data
    DateTime[] original = new DateTime[10];
    for (int i = 0; i < original.Length; i++)
        original[i] = new DateTime(2014, 1, i + 1);
    byte[] blob = new byte[original.Length * sizeof(DateTime)];
    fixed (DateTime* src = original)
    fixed (byte* dest = blob)
    {
        DateTime* typedDest = (DateTime*)dest;
        for(int i = 0; i < original.Length; i++)
        {
            typedDest[i] = src[i];
        }
    } 
