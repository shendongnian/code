    public static IEnumerable<int> Tester()
    {
        yield return 1;
        yield return 2;
        throw new Exception();
    }
    static void Main(string[] args)
    {
        Console.WriteLine(Tester().Any(x => x == 1));
        Console.WriteLine(Tester().Any(x => x == 2));
        
        try
        {
            Console.WriteLine(Tester().Any(x => x == 3));
        }
        catch
        {
        	Console.WriteLine("Error here");
        }
    }
