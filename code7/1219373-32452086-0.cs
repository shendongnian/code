    bool dirtyBool = true;
    while(dirtyBool)
    {   
    	if (move < 1)
    	{
    		Console.WriteLine("Enter a direction to move\n");
    
    		//forloop that allows the output to cycle the legth of array and branch to a new line on 4th output
    		for (int i = 0; i < width; i++)
    		{
    		  //for loop code
    		}
    		//This is the code i'm using to re trigger the previous loop with "move = 0"
    		ConsoleKeyInfo kb = Console.ReadKey();
    		if (kb.Key == ConsoleKey.UpArrow)
    		{
    			map[7, 1] = 1;
    			map[11, 1] = 0;
    			move = 0;
    			dirtyBool=false;
    			Console.WriteLine("FIre");
    		}
    	}
    	else
    	{
    		dirtyBool=false;
    		Console.WriteLine("END");
    	}
    }
