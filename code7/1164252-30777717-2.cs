    public static void MemoryBarrier()
    {
        int useless = 0;
        int temp = Volatile.Read(ref useless);
        Volatile.Write(ref useless, temp);
    }
