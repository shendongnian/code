	int rightGuess = 7;
	Console.WriteLine("Guess the right number from 1-10: ");
	int userGuess;
	userGuess = int.Parse(Console.ReadLine());
	{
		if (userGuess == rightGuess)
			Console.WriteLine("You guessed right!");
		else if (userGuess < rightGuess)
			Console.WriteLine("Wrong guess. Your guess was greater than the right guess.");
		else (userGuess > rightGuess)
			Console.WriteLine("Wrong guess. Your guess was lesser than the right guess.");
	}
	
