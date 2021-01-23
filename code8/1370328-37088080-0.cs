    ulong n = 18; // 10010
    ulong b = 1;
    int p = 0;
    for (int i = 0; i < 63; i++)
    {
        if ((n & b) == b)
        {
            p = i;
            break;
        }
        b = b << 1;
    }
    Console.WriteLine(p);
