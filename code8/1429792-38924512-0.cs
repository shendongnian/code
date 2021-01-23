    string input = Console.ReadLine();
	float f;
	int i;
	if (int.TryParse(input, out i)) {
		Console.WriteLine("Input {0} is of type int", i);
	} else if (float.TryParse(input, out f)) {
		Console.WriteLine("Input {0} is of type float", f);
	} else {
		Console.WriteLine("Input {0} is of type string", input);
	}
