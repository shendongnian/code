    while (alreadyUsedReagents.Count != 8)
    {
        int r = rnd.Next(reagents.Count);
        string pickedReagent = (string)reagents[r];
        if (!alreadyUsedReagents.Contains(pickedReagent))
        {
            alreadyUsedReagents.Add(pickedReagent);
            chosenReagent = pickedReagent;
            break;
        }
    }
    RefreshReagents();
    if (chosenReagent == null)
    {
        // make sure to come up with some default
        // or your method will return null in some cases
    }
