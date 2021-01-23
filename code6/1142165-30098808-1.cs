    Dictionary<string, string> dict = new Dictionary<string, string>();
    if (nouns.Count == descriptions.Count)
    {
        for (int i = 0; i < nouns.Count; i++)
        {
            dict.Add(nouns[0], descriptions[0]);
        }
    }
