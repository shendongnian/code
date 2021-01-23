    List<string> lines = File.ReadAllLines(inputFile).ToList<string>();
    List<string> data = new List<string>();
    List<int> allIndices = lines.Select((s, i) => new { Str = s, Index = i })
        .Where(x => x.Str.Contains("'"))
        .Select(x => x.Index).ToList<int>();
    for (int j = 0; j < allIndices.Count() - 1; j++)
        data.AddRange(lines.GetRange(allIndices[j], (allIndices[j + 1] - allIndices[j])));
