    while (true) {
	    string input = Console.ReadLine();
		float f;
		int i;
		if (int.TryParse(input, out i)) {
			Console.WriteLine("Input is of type int");
		} else if (float.TryParse(input, out f)) {
			Console.WriteLine("Input is of type float");
		} else {
			Console.WriteLine("Input is of type string");
		}
	}
