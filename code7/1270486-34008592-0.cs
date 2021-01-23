    static void Main(string[] args)
    {
        List<BitArray> lotterynumbers = GetLastWinningNumbers();
        BitArray usernumbers = new BitArray(MAX_LOTTERY_NUMBER);
        Console.Write("Please enter six numbers for the lottery: \n");
        for (int i = 0; i < 6; i++)
            usernumbers[Convert.ToInt32(Console.ReadLine())] = true;
        BitArray bestmatches = new BitArray(MAX_LOTTERY_NUMBER);
        BitArray bestweek = bestmatches;
        foreach (BitArray weeknumbers in lotterynumbers)
        {
            BitArray currentmatches = usernumbers.And(weeknumbers);
            if (currentmatches.Count > bestmatches.Count)
            {
                bestmatches = currentmatches;
                bestweek = weeknumbers;
            }
        }
        Console.WriteLine("\n\nYour week with the most matches was...");
        foreach (int number in bestweek)
        {
            Console.Write(number);
            Console.Write(' ');
        }
        Console.WriteLine("\n\nPress any key to continue: ");
        Console.ReadKey();
    }
