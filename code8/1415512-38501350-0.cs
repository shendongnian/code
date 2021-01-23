    public static void Main ()
		{
			PlayGame ();
			Console.WriteLine ("Press 'n' key to exit the application, press any other key to play again.");
			string again = Convert.ToString(Console.ReadKey ());
			if (again == "n") {
				Environment.Exit (0);
			}
			PlayGame ();
		}
		public static void PlayGame ()
		{
			Console.Clear ();
			Console.ForegroundColor = ConsoleColor.Cyan;
			int randomNumber;
			int userInput;
			int gameover = 0;
			Random number = new Random ();
			randomNumber = number.Next (1, 1001);
			Console.WriteLine ("Guess the number!");
			while (gameover != 1) 
			{
				userInput = Convert.ToInt32(Console.ReadLine());
				if (userInput == randomNumber) {
					Console.Clear ();
					Console.WriteLine ("Congrats!");
					return;
				} else if (userInput <= randomNumber) {
					Console.Clear ();
					Console.WriteLine ("Guess Higher!");
				} else if (userInput >= randomNumber) {
					Console.Clear ();
					Console.WriteLine ("Guess Lower!");
				}
			}
		}
