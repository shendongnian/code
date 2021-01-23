    // Newer syntax.
    if (int.TryParse(args.Value, out var value))
    {
      args.IsValid = value > 0;
    }
    // Older supported version which resolved the issue.
    int value;
    if (int.TryParse(args.Value, out value))
    {
      args.IsValid = value > 0;
    }
