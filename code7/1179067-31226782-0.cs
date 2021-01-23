	DateTime from = new DateTime(1960,1,1);
	DateTime to = new DateTime(1990, 12, 31);
	DateTime input = DateTime.Now;
	Console.WriteLine(from <= input && input <= to); // False
	input = new DateTime(1960,1,1);
	Console.WriteLine(from <= input && input <= to); // True
