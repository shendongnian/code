    static void Main(string[] args)
    {
        int val = 1;
        int val2 = 1;
        Add(ref val);
        Add(val2);
        Console.WriteLine("Add 44 to Refence of val: " + val);
        Console.WriteLine("Add 44 to i, not by ref:  " + val2);
        Console.ReadKey();
    }
    static void Add(ref int i)
    {
        i += 44;
    }
    static void Add(int i)
    {
        i += 44;
    }
