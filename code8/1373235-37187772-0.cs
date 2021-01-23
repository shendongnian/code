                string choice = string.Empty;
                bool goodChoice = false;
				while (!goodChoice)
				{
					Console.Clear();
					Console.WriteLine(string.Empty);
					Console.WriteLine("Do you really want to hurt me?");
					Console.WriteLine(string.Empty);
					Console.WriteLine(string.Empty);
					Console.WriteLine("Please Y or N (or 0 to exit)");
					choice = Console.ReadLine().Trim();
					if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
					{
						goodChoice = true;
					}
					if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
					{
						goodChoice = true;
					}
					if (choice.Equals("0"))
					{
						goodChoice = true;
						return; /* exist the routine */
					}
				}
