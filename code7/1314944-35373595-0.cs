    var processedLines = File.ReadLines(inputFile).AsParallel()
        .Select(l => MyComplexMethodReturnsAString(l));
    using (var output = File.AppendText(outputFile))
    {
        output.AutoFlush = true;
        foreach (var processedLine in processedLines)
            output.WriteLine(processedLine);
    }
