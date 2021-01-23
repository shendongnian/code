    Parallel.ForEach(
        System.IO.File.ReadLines(inputFile),
        new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
        (line, _, lineNumber) =>
        {
            ...
        }
