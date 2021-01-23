    public static int GetNextIndex(List<string> names, string seedName)
    {
        var namesWithSeed = names.Where(n => !string.IsNullOrEmpty(n) && n.StartsWith(seedName));
        if (names.Count == 0)
            return 1;
        int temp = 0;
        var allIntsStringsForSeed = namesWithSeed
                                    .Select(n => n.Replace(seedName, string.Empty))
                                    .Select(s => int.TryParse(s, out temp) ? temp : 0)
                                    .OrderBy(i => i)
                                    .ToList();
        var idx = 0;
        for (int i = 0; i < allIntsStringsForSeed.Count; i++)
        {
            if (i == allIntsStringsForSeed.ElementAt(i))
                idx = i;
            else
                break;
        }
        return idx == 0 ? 1 : idx + 1;
    }
