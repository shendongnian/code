    class Program
    {
    	static public void Main(string[] args)
    	{
    		// Get input
    		Console.WriteLine("Please enter numbers seperated by spaces");
    		string input = Console.ReadLine();
    		string[] splittedInput = input.Split(' ');
    		
    		// Insure numbers are actually inserted
    		while (splittedInput.Length <= 0) 
    		{
    			Console.WriteLine("No numbers inserted. Please enter numbers seperated by spaces");
    			splittedInput = input.Split(' ');
    		}
    		
    		// Try and parse the strings to integers
    		// Possible exceptions : ArgumentNullException, FormatException, OverflowException
    		// ArgumentNullException shouldn't happen because we ensured we have input and the strings can not be empty
    		// FormatException can happen if someone inserts a string that is not in the right format for an integer,
    		// 		Which is : {0,1}[+\-]{1,}[0-9]
    		// OverflowException happens if the integer inserted is either smaller than the lowest possible int
    		//		or bigger than the largest possible int
    		// We keep the 'i' variable outside for nice error messages, so we can easily understand
    		// What number failed to parse
    		int[] numbers = new int[splittedInput.Length];
    		int i = 0;
    		try
    		{
    			for (; i < numbers.Length; ++i)
    			{
    				numbers[i] = int.Parse(splittedInput[i]);
    			}
    		}
    		catch (FormatException)
    		{
    			Console.WriteLine("Failed to parse " + splittedInput[i] + " to an integer");
    			return;
    		}
    		catch (OverflowException)
    		{
    			Console.WriteLine(splittedInput[i] + " is either bigger the the biggest integer possible (" +
    				int.MaxValue + ") or smaller then the lowest integer possible (" + int.MinValue);
    			return;
    		}
    		
    		// Save min and max values as first number
    		int minValue = numbers[0], maxValue = numbers[0];
    		
    		// Simple logic from here - number lower than min? min becomes numbers, and likewise for max
    		for (int index = 1; index < numbers.Length; ++i)
    		{
    			int currentNumber = numbers[index];
    			minValue = minValue > currentNumber ? currentNumber : minValue;
    			maxValue = maxValue < currentNumber ? currentNumber : maxValue;
    		}
    		
    		// Show output
    		Console.WriteLine("Max value is : " + maxValue);
    		Console.WriteLine("Min value is : " + minValue);
    	}
    }
