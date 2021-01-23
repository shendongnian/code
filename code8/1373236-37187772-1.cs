                string choice = string.Empty;
                bool goodChoice = false;
				while (!goodChoice)
				{
					Console.Clear();
					Console.WriteLine(string.Empty);
					Console.WriteLine("Enter an Integer between {0} and {1}", minValue, maxValue);
					Console.WriteLine(string.Empty);
					Console.WriteLine(string.Empty);
					Console.WriteLine("Please enter an integer (or X to exit)");
					choice = Console.ReadLine().Trim();
					int intParseResult = 0;
					bool intParseAttempt = int.TryParse(choice, out intParseResult);
					if(!intParseAttempt)
					{
						goodChoice = false;
					}
					else
					{
							if ((intParseResult < minValue) || (intParseResult > maxValue))
							{
											Console.WriteLine("Out of Range");
							}
							else
							{
								goodChoice = true;
							}
					}
					if (choice.Equals("X"))
					{
						goodChoice = true;
						return -99999; /* you'll have to figure out how to handle exits on your own */
					}
				}
