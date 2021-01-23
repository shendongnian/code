    static ulong xorshift64star(ulong x)
    {
        x ^= x >> 12; // a
        x ^= x << 25; // b
        x ^= x >> 27; // c
        return x * 2685821657736338717ul;
    }
    static void Main(string[] args)
    {
        byte[] buf = new byte[512 * 1024 * 1024];
        Random rnd = new Random();
        ulong value = (uint)rnd.Next(int.MinValue, int.MaxValue);
        long collisions = 0;
        Stopwatch sw = Stopwatch.StartNew();
        for (long i = 0; i < uint.MaxValue; ++i)
        {
            if ((i % 1000000) == 0)
            {
                Console.WriteLine("{0} random in {1:0.00}s (c={2})", i, sw.Elapsed.TotalSeconds, collisions - 1000000);
                collisions = 0;
            }
            uint randomValue; // result will be stored here
            bool collision;
            do
            {
                value = xorshift64star(value);
                randomValue = (uint)value;
                collision = (buf[randomValue >> 4] & (1 << (int)(randomValue & 7))) != 0;
                ++collisions;
            }
            while (collision);
            buf[randomValue >> 4] |= (byte)(1 << (int)(randomValue & 7));
        }
        Console.ReadLine();
    }
