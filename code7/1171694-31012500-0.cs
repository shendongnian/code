		static ShotgunOption GetOptionFromUser()
        {
            char menuItem;
            DisplayMenu();
            Console.WriteLine("Please Select A Option");
            menuItem = char.ToUpper(char.Parse(Console.ReadLine()));
			while(true)
			{
				switch(menuItem)
				{
					case 'S': return ShotgunOption.Shoot; break;
					case 'P': return ShotgunOption.Shield; break;
					case 'R': return ShotgunOption.Reload; break;
					case 'X': return ShotgunOption.Exit; break;
					default:
						Console.WriteLine("Error - Invalid menu item");
						DisplayMenu();
						menuItem = char.ToUpper(char.Parse(Console.ReadLine()));
				}
			}
		
            return ShotgunOption.Exit; // to keep compiler happy
        }
