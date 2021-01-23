    static void Main()
    {
        int diceRoll;
        int roll1 = 0;
        int roll2 = 0;
        int roll3 = 0;
        Console.WriteLine("Enter the number of dice to roll");
        diceRoll = Convert.ToInt32(Console.ReadLine());
        RollDice(ref diceRoll, ref roll1, ref roll2, ref roll3);
        Console.WriteLine("Your dice rolled:");
        Console.WriteLine("{0}{1}{2}{3}", diceRoll, roll1, roll2, roll3
    }
    static void RollDice(ref int diceRoll, ref int roll1, ref int roll2, ref int roll3)
    {
        Random die = new Random();
        if (diceRoll == 1)
        {
            roll1 = die.Next(1, 7);
        }
        else if (diceRoll == 2)
        {
            roll1 = die.Next(1, 7);
            roll2 = die.Next(1, 7);
        }
        else if (diceRoll >= 3)
        {
            roll1 = die.Next(1, 7);
            roll2 = die.Next(1, 7);
            roll3 = die.Next(1, 7);
        }
        else
        {
            //You probably typed 0 since you got here without crashing the program
        }
    }
