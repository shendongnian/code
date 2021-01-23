	// user input = y or n
	string choice;
	// user pin
	int pin = 0;
	// state that indicates if the user wants to continue or not
	bool continueLoop = false;
	do
	{
		// greet user
		Console.WriteLine("welcome to HSPUIC bank would you like to make a withdraw today N or Y");
		// take input
		choice = Console.ReadLine();
		// check if user has entered valid input
		if (choice.ToLower() == "y" || choice.ToLower() == "n")
		{
			// default decision is "user does not want to continue" = exit
			continueLoop = false;
			// user has choosen to continue
			if (choice.ToLower() == "y")
			{
				// user wants to do something, so stay in the loop
				continueLoop = true;
				// ask for pin
				Console.WriteLine("Enter your pin");
				var pinAsText = Console.ReadLine();
				// 	convert the pin to number: if (int.TryParse(pinAsText, out pin)) ...
				if (pinAsText == "1234")
				{
					Console.WriteLine("PIN correct");
					// continue with logic here, for example take amount
				}
				else
				{
					Console.WriteLine("PIN incorrect");
				}
			}
		}
		else
		{
			Console.WriteLine("Please enter Y or N");
			continueLoop = true;
		}
	} while (continueLoop);
	Console.WriteLine("goodbye");
