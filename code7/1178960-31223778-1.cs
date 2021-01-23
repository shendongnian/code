    Console.WriteLine("Welcome to the Days on Earth Finder!" +
	"\nPlease input your birthday(MM/DD/YYY):");
	//Console.ReadLine();
	//string myBirthday = Console.ReadLine();
	//DateTime mB = Convert.ToDateTime(myBirthday);
	//DateTime myBirthday = DateTime.Parse(Console.ReadLine());
	string myBirthday = Console.ReadLine();
	DateTime mB = DateTime.Parse(myBirthday);
	//This line is where the error occurs
	TimeSpan myAge = DateTime.Now.Subtract(mB);
	Console.WriteLine("You are " + myAge.TotalDays + " days old!");
	Console.ReadLine();
