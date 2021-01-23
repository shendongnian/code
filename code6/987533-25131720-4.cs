    const string originalFile = @"D:\Temp\file.txt";
	const string newFile = @"D:\Temp\newFile.txt";
	// Retrieve all lines from the file.
	string[] linesFromFile = File.ReadAllLines(originalFile); 
	List<string> linesToAppend = new List<string>();
	foreach (string line in linesFromFile)
	{
		// 1. Split the line at the semicolon.
		// 2. Take the first index, because the first part is your required result.
		// 3. Trim the trailing and leading spaces.
		string appendAbleLine = line.Split(';').FirstOrDefault().Trim();
    
        // Add the line to the list of lines to append.
		linesToAppend.Add(appendAbleLine);
	}
	// Append all lines to the file.
	File.AppendAllLines(newFile, linesToAppend);
