    var runeTotals = new Dictionary<string, int>();
    foreach(RuneSlot runeSlot in rune.Slots)
    {
        var runeName = staticApi.GetRune();
        if (runeTotals.ContainsKey(runeName))
        {
            runeTotals[runeName] += 1;
        }
        else
        {
            runeTotals.Add(runeName, 1);
        }
    }
