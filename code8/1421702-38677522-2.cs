    if (string.IsNullOrEmpty(term))
    {
        filteredResults = itemsList;
    }
    else
    {
        filteredResults = itemsList
                 .Where(s => s.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) >= 0);
    }
