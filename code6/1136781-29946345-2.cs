    static void Main()
    {	
    	//Pass the no. of dice rolls and an array of integer which holds the results
    	//Note that you can't pass a value less than zero in the first parameter since we used uint instead of int
    	//Also note that you can pass an uninitialized array since we are using the out keyword
    	//I'll leave knowing the difference between the different data types, out/ref keywords to you
    	int[] results;	
    	RollDice(3, out results);
    
    	for (var i = 0; i < results.Length; i++)
    	{
    		Console.WriteLine("Dice Roll #{0}: {1}", i + 1, results[i]);
    	}
    
    	Console.ReadKey();
    }
