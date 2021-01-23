    foreach(var y in Enumerable.Range(0,lines.Count()))
    {
        foreach(var word in lines[y].Split())
        {
            WordStats wordStat;
            bool alreadyHave = words.TryGetValue(word, out wordStat);
            if (alreadyHave)
            {
                wordStat.Count++;
                wordStat.AppearsInLines.Add(y);
            }
            else
            {
                wordStat = new WordStats();
                wordStat.Count = 1;
                wordStat.AppearsInLines.Add(y);
                wordStats.Add(word, wordStat);
            }
