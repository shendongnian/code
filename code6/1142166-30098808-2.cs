    List<string> temp = new List<string>();
    if(nouns.Count == descriptions.Count)
    {
        for(int i = 0; i < nouns.Count; i++)
        {
            temp.Add(string.format("{0} {1}", nouns[i], descriptions[i]));
        }
    }
