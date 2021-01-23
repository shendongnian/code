	string[] array1 = { "cat", "dog", "carrot", "bird" };</br>
	//
	// Find first element starting with substring.
	//
	string value1 = Array.Find(array1,
	    element => element.StartsWith("car", StringComparison.Ordinal));</br>
	//
	// Find first element of three characters length.
	//
	string value2 = Array.Find(array1,
	    element => element.Length == 3);
	//
	// Find all elements not greater than four letters long.
	//
	string[] array2 = Array.FindAll(array1,
	    element => element.Length <= 4);
	Console.WriteLine(value1);
	Console.WriteLine(value2);
	Console.WriteLine(string.Join(",", array2));
