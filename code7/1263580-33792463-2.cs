    Console.WriteLine("please enter date as dd/MM/yyyy");
		
	DateTime date;
	if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, DateTimeStyles.None, out date))
	{
		Console.WriteLine("Correct date: {0}", date.ToString("dd/MM/yyyy"));
	}
	else
	{
		Console.WriteLine("Invalid date!");
	}
		
	Console.ReadLine();
