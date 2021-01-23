    // Read all lines into an array
    string[] lines = File.ReadAllLines(@"C:\path\to\your\file.txt");
    // Loop through each one
    foreach (string line in lines)
    {
        // Split into an array based on the : symbol
	    string[] split = line.Split(':');
        // Get the column based on index
	    Console.WriteLine(split[3]);
    }
