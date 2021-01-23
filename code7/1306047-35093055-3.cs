		int start = 0;
		int end = 100;
		Random myRandom = new Random(); 
		int computer = myRandom.Next(start, end);
		int count = 0;
		int guess = 999;
					
		while (guess != computer)
		{
			guess = (end - start) / 2 + start;
			if (guess > computer)
			{
				end = guess;
				Console.WriteLine("Your guess is too high, next guess: {0}", guess);
			}
			else
			{
				start = guess;
				Console.WriteLine("Your guess is too low, guess again: {0}", guess);
			}
			
			count = count + 1;
			Console.WriteLine("Count {0}", count);
			
		}
		Console.WriteLine("You got it. The number is {0}. It took you {1} guesses.", computer, count);
		Console.ReadKey();
