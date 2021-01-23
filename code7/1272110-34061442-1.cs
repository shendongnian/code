	string invoer = Console.ReadLine();
	if (string.IsNullOrEmpty(invoer))
		break;
	int getal;
	if (!int.TryParse(invoer, out getal))
	{
		Console.WriteLine("Invalid value '{0}'", invoer);
		continue;
	}
