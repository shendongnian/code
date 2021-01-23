    private volatile static int Useless = 0;
    public static void MemoryBarrier()
    {
        int temp = Useless;
        Useless = temp;
    }
