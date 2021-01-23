    static string chooseCharacterName() //Method allows the user to enter their name and will loop until user chooses 1 and accepts.
    {
    	string charName;
    	string areYouHappyWithThisName;
    	UInt32 validName = 0;
    	Console.Write("Please enter a character name: ");
    	string charNameAsText = Console.ReadLine();
    	charName = Convert.ToString(charNameAsText);
    	Console.WriteLine("You have chosen: " + charName);
    	Console.WriteLine();
    	while (true)
    	{
    
    		Console.Write("Do you want to keep this name? Type 1 for Yes, Type 2 for No. If No then choose again:  ");
    		areYouHappyWithThisName = Console.ReadLine();
    		if (!UInt32.TryParse(areYouHappyWithThisName, out validName))
    		{
    			Console.WriteLine();
    			Console.WriteLine("Please try again. Enter 1 for Yes and 2 for No");
    		}
    		else if (validName > 2 || validName < 1)
    		{
    			Console.WriteLine();
    			Console.WriteLine("Please try again. Enter 1 for Yes and 2 for No");
    		}
    		else if(validName == 2)
    		{
    			Console.WriteLine();
    			chooseCharacterName(); //this method contains the whole routine
    		}
    		else
    		{
    			Console.WriteLine();
    			Console.WriteLine("Good luck " + charName + ", you're going to need it!");
    			break; //leave this break here
    		}
    		//break; //I don't think you want this break
    	}
    	
    	return charName;
    }
