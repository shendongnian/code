    string[] fileLines = IO.File.ReadAllLines("input file path");
    List<string> resultLines = new List<string>();
    foreach (string line in fileLines) {
    	string[] parts = line.Split("  "); //Double space
    	if (parts.Count() > 1) {
    		string lastPart = parts.LastOrDefault();
    		if (!string.IsNullOrEmpty(lastPart)) {
    			resultLines.Add(lastPart);
    		}
    	}
    }
    IO.File.WriteAllLines("output file path", resultLines.ToArray());
