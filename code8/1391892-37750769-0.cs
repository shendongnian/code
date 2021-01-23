    File.WriteAllLines(
        outputFileName,
        File.ReadLines(inputFileName)
            .Select(line =>
                {
                    var splits = line.Split(new [] {' '}};
                    var firstWord = new string(splits[0].OrderBy(c => c));
                    var newLine = firstWord + line.Substring(firstWord.Length);
                    return newLine;
                }));
        
