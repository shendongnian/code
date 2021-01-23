    // File paths.
    const string inFile = "in.txt";
    const string outFile = "out.txt";
    // Read file.
    var inContents = File.ReadAllText(inFile);
    // Organize contents.
    var contentsArray = inContents.Replace(Environment.NewLine, ",")
        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    // Sort contents.
    var sortedContents = contentsArray.OrderBy(c => c);
    // Write file.
    File.WriteAllText(outFile, string.Join(",", sortedContents));
