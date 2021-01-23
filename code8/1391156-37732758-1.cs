    static void Merge(string inputFile1, string inputFile2, string outputFile)
    {
    	Func<string, IEnumerable<KeyValuePair<int, string>>> readLines = file =>
    		File.ReadLines(file).Select(line => 
    		    new KeyValuePair<int, string>(int.Parse(line), line));
    	var inputLines1 = readLines(inputFile1);
    	var inputLines2 = readLines(inputFile2);
    	var comparer = Comparer<KeyValuePair<int, string>>.Create(
    		(a, b) => a.Key.CompareTo(b.Key));
    	var outputLines = inputLines1.MergeOrdered(inputLines2, comparer)
    		.Select(item => item.Value);
    	File.WriteAllLines(outputFile, outputLines);
    }
