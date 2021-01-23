	Console.WriteLine("I'm thinking of a number between 1 - 10");
	do
	{
		while(!int.TryParse(Console.ReadLine(), out guess))
		{
			//not valid number - enter again
		}
		//insert your if statement about whether guess is correct
		if(counter >= 5)
		{
			//unable to guess in 5 moves
			break;
		}
	}while(guess != number)
	Console.WriteLine("Would you like to play again? (y/n)");
	userChoice = Console.ReadLine();
	if (userChoice == "n")
	{
		over = true;
	}
----
    List<int> guesses = new List<int>()
    bool guessed = true;
    while(guessed)
    {
        foreach(int g in guesses)
        {
             if(g == guess)
             {
                 break;
             }
        }
        guesses.Add(guess);
        guessed = false;
    }
