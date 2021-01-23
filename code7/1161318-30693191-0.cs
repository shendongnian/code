    public static IEnumerable GetDuplicates(IDictionary<string, List<string>> dict)
    {
        var previousValues = new List<List<string>>(two_dict.Count);
        foreach (var kvp in dict)
        {
            if (previousValues.Any(v => v.SequenceEqual(kvp.Value))
                yield return kvp.Key;
            else
                previousValues.Add(kvp.Value);
        }
    }
