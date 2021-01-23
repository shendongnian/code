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
					case 'S': return ShotgunOption.Shoot;
					case 'P': return ShotgunOption.Shield;
					case 'R': return ShotgunOption.Reload;
					case 'X': return ShotgunOption.Exit;
					default:
						Console.WriteLine("Error - Invalid menu item");
						DisplayMenu();
						menuItem = char.ToUpper(char.Parse(Console.ReadLine()));
				}
			}
		
            return ShotgunOption.Exit; // to keep compiler happy
        }
