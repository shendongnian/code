			Console.Write("Color To Bet on: ");
			string tempColor = Console.ReadLine();
			bool success = false;
			while (!success)
			{
				if (string.IsNullOrEmpty(tempColor))
				{
					success = false;
					Console.Write("The color can't be null.");
					tempColor = Console.ReadLine();
					continue;
				}
				tempColor = tempColor.First().ToString().ToUpper() + tempColor.Substring(1); //e.g. 'black' will not convert to MyColor.Black
				MyColor selectedColor;
				success = Enum.TryParse<MyColor>(tempColor, out selectedColor);
				if (!success)
				{
					Console.WriteLine("You should enter 'Black', 'Green' or 'Red'!");
					tempColor = Console.ReadLine();
				}
			}
