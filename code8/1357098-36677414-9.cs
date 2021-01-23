    private unsafe static void Test(Int32* ptr, Int32 size)
    {
        Console.WriteLine("test");
        for (int i = 0; i < size; i++)
        {
            var a = * (ptr + i);
            *(ptr + i) = a;
        }
    }
