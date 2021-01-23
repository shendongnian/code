	char a = 'y';
	while (char.ToLower(a) == 'y')
	{
		Console.WriteLine("Please enter the crate Length for your incoming shipment:");
		double l = double.Parse(Console.ReadLine());
		Console.WriteLine("Enter the crate Width for your incoming shipment:");
		double w = double.Parse(Console.ReadLine());
		Console.WriteLine("Enter the crate Height for your incoming shipment:");
		double h = double.Parse(Console.ReadLine());
		double totalDims = l * w * h;
		double volKg = totalDims / 366;
		Console.WriteLine("Your total Vol Kg is {0:0.00}", volKg);
		Console.WriteLine();
		Console.WriteLine("Are there any additional crates y/n? ");
		a = char.Parse(Console.ReadLine());
		Console.WriteLine();
	}
