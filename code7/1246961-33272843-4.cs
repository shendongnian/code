    const int DICE_ROLLS = 51;
    static void Main(string[] args)
    {
    	Random random = new Random();
    	int[] firstDice = new int[DICE_ROLLS];
    	int[] secondDice = new int[DICE_ROLLS];
    	int[] count = new int[6];
    	int diceSum = 0;
    	
    	for (int roll = 0; roll <= DICE_ROLLS - 1; roll++)
    	{
    		firstDice[roll] = GenerateNumber(random);
    		secondDice[roll] = GenerateNumber(random);
    		diceSum = firstDice[roll] + secondDice[roll];
    		Console.WriteLine("ROLL {0}:  {1} + {2} = {3}", roll + 1, firstDice[roll], secondDice[roll], diceSum);
    	}
    	Console.WriteLine();
    	Console.WriteLine("~~~~~~~~~~~~~~~~");
    	Console.WriteLine("Number Frequency");
    	
    	var allRolls = firstDice.Concat(secondDice).ToList();	
    	for(var i = 1; i <= 6; i++)
    	{
    		Console.Write(i + ": ");
    		for(var j = 0; j < allRolls.Count(c => c == i); j++)
    			Console.Write("|");
    		Console.WriteLine();
    	}
    }
    
    
    static int GenerateNumber (Random random)
    {
       return random.Next(1, 7);
    }
