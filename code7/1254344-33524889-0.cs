    int userSelection = 0;
    bool validAnswer = false;
    do
    {
    	Console.WriteLine("[1]  Encryption");
    	Console.WriteLine("[2]  Decryption");
    	Console.WriteLine("[3]  Exit");
    
    	Console.Write ("Please choose an option 1-3:  ");
    	userSelection = Int32.Parse(Console.ReadLine()); 
    
    	switch(userSelection)
    	{   
    		case 1:
    			readFile();
    			validAnswer = true;
    			break;
    
    		case 2:
    			decryption();
    			validAnswer = true;
    			break;
    
    		case 3:
    			validAnswer = true;
    			Environment.Exit(0);
    			break;
    		default:
    			Console.Clear();
    			Console.WriteLine("Your selection is invalid. Please     try again.");
    			break;
    	}
    
    }while (!validAnswer);
