    public static void DoIt(Int32 times, Func<int, bool> action)
    {
        for (var i = 0; i < times; i++)
        {
            if (!action(i))
            {
                break;
            }
        }
        Console.WriteLine("Done");
        Console.ReadLine();
    }
    static void Main(string[] args)
    {
        DoIt(5, i =>
        {
            Console.WriteLine(i);
            return i != 3;              // returning false exits the loop
        });
    }
