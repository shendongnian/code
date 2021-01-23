    static Func<int> Natural()
    {
    int seed = 0;
    return () => seed++; // Returns a closure
    }
    static void Main()
    {
    Func<int> natural = Natural();
    Console.WriteLine (natural()); // 0
    Console.WriteLine (natural()); // 1
    }
