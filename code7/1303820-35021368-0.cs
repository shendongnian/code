    foreach (string line in lines)
    {
        if (!String.IsNullOrWhiteSpace(line))
        {
          clearPath(line.trim());
        }
    }
