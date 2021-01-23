    static List<string> combinations = new List<string> {
        "1 0 30 15 100 23",
        "12 23 10 12 0 1"
    };
    
    public static void Main()
    {
        Console.WriteLine("Enter six numbers to check the combinations:");
        int a1 = int.Parse(Console.ReadLine());
        int a2 = int.Parse(Console.ReadLine());
        int a3 = int.Parse(Console.ReadLine());
        int a4 = int.Parse(Console.ReadLine());
        int a5 = int.Parse(Console.ReadLine());
        int a6 = int.Parse(Console.ReadLine());
        FindWinners(a1, a2, a3, a4, a5, a6);
        Console.ReadLine();
    }
    
    private static void FindWinners(params int[] numbers)
    {
        foreach (int[] combo in combinations
            // This select makes a string array
            .Select(c => c.Split(' '))
            // This select turns the string array into an integer array
            .Select(combination => combination
                .Select(c => Convert.ToInt32(c))
                .ToArray()))
        {
            Array.Sort(combo);
            Array.Sort(numbers);
            Console.WriteLine(combo.SequenceEqual(numbers) 
                                    ? "Winner!"
                                    : "Loser!");
        }
    }
