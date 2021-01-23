    public static IEnumerable GetDuplicates(IDictionary<string, List<string>> dict)
    {
        var previousItems = new List<KeyValuePair<string, List<string>>>(dict.Count);
        var matchedItems = new List<bool>();
        foreach (var kvp in dict)
        {
            var match = previousItems.Select((kvp2, i) => Tuple.Create(kvp2.Key, kvp2.Value, i)).FirstOrDefault(t => kvp.Value.SequenceEqual(t.Item2));
            if (match != null)
            {
                var index = match.Item3;
                if (!matchedItems[index])
                {
                    yield return match.Item1;
                    matchedItems[index] = true;
                }
                yield return kvp.Key;
            }
            else
            {
                previousItems.Add(kvp);
                matchedItems.Add(false);
            }
        }
    }
