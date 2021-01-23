        int chevyWins = 0, fordWins = 0;
		for (int i = 0; i < 8; i++)
		{
			if (chevy[i] < ford[i])
			{
				//Note the difference with your code, your are doing 
				//the subtraction chevy[i] - ford[i] that will give you negative numbers.
				chevyWins++;
				Console.WriteLine(String.Format("Chevy won by {0}", (ford[i] - chevy[i])));
			}
			else if (chevy[i] > ford[i])
			{
				fordWins++;
				Console.WriteLine(String.Format("Ford won by {0}", (chevy[i] - ford[i])));
			}
			else
			{
				Console.WriteLine("Tie!");
			}
		}
		if (chevyWins > fordWins)
		{
			Console.WriteLine("Chevy Wins the competition!");
		}
		else if (chevyWins < fordWins)
		{
			Console.WriteLine("Ford Wins the competition!");
		}
		else
		{
			Console.WriteLine("The competition was tie!");
		}
