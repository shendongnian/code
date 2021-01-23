    List<string> lines = File.ReadAllLines(file).ToList<string>();
    List<string> validations = new List<string>();
    List<int> allIndices = lines.Select((s, i) => new { Str = s, Index = i })
        .Where(x => x.Str.Contains(validationHeader))
        .Select(x => x.Index).ToList<int>();
    for (int j = 0; j < allIndices.Count() - 1; j++)
    {
        int count = (allIndices[j + 1] - allIndices[j]);
        validations.Add(GetString(lines.GetRange(allIndices[j], count)));
    }
