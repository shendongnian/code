    static void main()
    {
        ulong i = 0;
        while (i < 100000000000)
        {
            Console.WriteLine(i);
            Console.Out.Flush();
            i++;
        }
    }
