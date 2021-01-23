    var first = bar.FirstOrDefault(c => !c.Value);
    if (first == null)
    {
        ...
    }
    else
    {
        // Use first, I suspect.
        // (You don't in the sample code, but...)
    }
