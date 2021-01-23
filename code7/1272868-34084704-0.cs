    do
    {
        for (int i = 0; i < NoOfPlayers; i++)
        {
			do
			{
			   ...
				do
				{
					...
					if (CheeseX > 7 || CheeseX < 0)
		
						Console.WriteLine("Please enter a number from 0 to 7");
					else
						break;
				} while (true);
		
				do
				{
					...
					if (CheeseY > 7 || CheeseY < 0)
						Console.WriteLine("Please enter a number from 0 to 7");
					else
						break;
				} while (true);
		
				if (!TryToPlaceCheese(CheeseX, CheeseY))
				{
					string CheeseisHere = "There is already a piece of cheese at this location.";
					Console.SetCursorPosition((Console.WindowWidth - CheeseisHere.Length) / 2, Console.CursorTop);
					Console.WriteLine(CheeseisHere);
		
				}
				else
				{
					Board[CheeseX, CheeseY] = SquareState.gotCheese;
					TotalCheesePlaced = (TotalCheesePlaced + 1);
				}
			} while (!TryToPlaceCheese(CheeseX, CheeseY));
		}
    } while (TotalCheesePlaced < 16);
