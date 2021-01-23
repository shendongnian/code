	static void menu()
	{
		double[] groceries = new double[] { 3000, 1000, 10000, 6000, 2000 }; // By creating an array, you can easily get the price of an item by the index.
		// double[] groceries = new double[] { stove, lemonsqeezer, oven, blender, potcollection };
		
		// double[] electronics_and_appliances = new double[] { ... };
		
		Console.WriteLine("Select a category to view");
		Console.WriteLine("");
		Console.WriteLine("1.Groceries");
		Console.WriteLine("2.Electronics & Appliances");
		Console.WriteLine("3.Exit");
		
		int response = int.Parse(Console.ReadLine());
		
		switch (response)
		{
			case 1:
				Console.WriteLine("...........Groceries...............");
				Console.WriteLine("");
				Console.WriteLine(@" Choose items being purchased from Groceries /n      
                   1:stove = 3000 \n 2: potcollection = 2000 \n
                   3:lemonsqeezer = 1000 \n 4:oven = 10000 \n 5:blender = 6000");
				Console.WriteLine("");
				Console.WriteLine("Enter a number from the above groceries list");
				
				// This prevents IndexOutOfRangeException.
				try
				{
					Console.WriteLine("The total is {0}", groceries[int.Parse(Console.ReadLine()) - 1]); // Minus one becuase index's start from 0.
				}
				catch
				{
					Console.WriteLine("That item doesn't exist");
				}
				
				break;
	
			case 2:
				Console.WriteLine("..............Electronics & Appliances............");
				/*
				
				Console.WriteLine("");
				Console.WriteLine(@"Choose items being purchased from Electronics & Appliances/n ...");
				Console.WriteLine("");
				Console.WriteLine("Enter a number from the above Electronics & Appliances list");
				
				try
				{
					Console.WriteLine("The total is {0}", electronics_and_appliances[int.Parse(Console.ReadLine()) - 1]);
				}
				catch
				{
					Console.WriteLine("That item doesn't exist");
				}
				
				*/
				break;
			case 3:
				Console.WriteLine("...........Exit...............");
				break;
		}
	}
	static void Main(string[] args)
	{
		menu();
	}
