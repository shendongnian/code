	while (true)
	{
		while (true)
		{
			Console.Write("- Enter the radius of the circle: ");
			double radius;
			if (double.TryParse(Console.ReadLine(), out radius) && radius > 0.0)
			{
				double area = Area(radius);
				double circumference = Circumference(radius);
				double diameter = Diameter(radius);
				Console.WriteLine();
				Console.WriteLine(Result(radius, area, circumference, diameter));
				break;
			}
			Console.WriteLine(" [Error] Radius must be a positive value!");
			Console.WriteLine();
		}
		string choice = "";
		while (true)
		{
			Console.Write("- Do you wish to make another calculation [Y or N]? ");
			choice = Console.ReadLine();
			if (new [] { "Y", "N", }.Contains(choice.ToUpper()))
			{
				break;
			}
			Console.WriteLine();
			Console.WriteLine("- Invalid choice! Press Y to continue or N to exit.");
		}
		if (choice.ToUpper() == "N")
		{
			break;
		}
		Console.WriteLine();
	}
	Console.WriteLine();
	Console.WriteLine("- Thank you for using me. Have a nice day!");
	Console.WriteLine();
