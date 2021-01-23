    foreach (string item in list.Distinct())
    {
        int startIndex = list.IndexOf(item);
        int endIndex = list.LastIndexOf(item);
        bool notGrouped = Enumerable.Range(startIndex, endIndex - startIndex + 1).Select(index => list[index]).Any(i => i != item);
        if (notGrouped)
        {
            // show message for the current item
        }
    }
