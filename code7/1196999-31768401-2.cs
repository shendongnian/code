    enum UserChoiceEnum
    {
    	Choice1 = 1,
    	Choice2,
    	Choice3
    }
    
    void Main()
    {
    	int atkchoice;
    	do
    	{
    		do
    		{
    			// repeat until input is a number
    			Console.WriteLine("Please input a number! ");
    		} while (!int.TryParse(Console.ReadLine(), out atkchoice));
    	} while (!Enum.IsDefined(typeof(UserChoiceEnum), atkchoice));
    	
    	Console.WriteLine("You entered {0}", atkchoice);
    }
