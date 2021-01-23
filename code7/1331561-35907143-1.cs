    public static void Main()
    {
    	int numCount = 0;
    	int sum = 0;
    	
    	string input;
    	do
    	{
    		
    		Console.Write("Enter number: ");
    		input = Console.ReadLine();
    		int num;
    		if (int.TryParse(input, out num))
    		{
    			sum += num;
    			numCount++;
    			Console.WriteLine("Sum is: " + sum);
    		}
    	} while (!(numCount > 2 && input == "00")); // Make sure at least two numbers and until user rpess '00'
    }
