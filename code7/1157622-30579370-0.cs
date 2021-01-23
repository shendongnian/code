    private static readonly _emptyTags = new List<string>();
    // ...
    // Get list with applicable tags.
    List<string> providedTags = (searchByTags != null)
        ? providedTags = searchByTags.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();
        : _emptyTags;
    // ...
    // Split based on whether any tags were provided as a filter.
    if (providedTags.Length > 0)
    {
        // Filter by tags
        vnVM.Quotes = db.SavedQuotes
            .Where(s => s.Tags.Any(t => providedTags.Contains(t.Name)))
            .ToList();
    }
    else 
    {
        // Get them all
        vnVM.Quotes = db.SavedQuotes.ToList(); // note: unbounded result set.
    }
