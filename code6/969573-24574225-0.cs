    string separator = "\n";
    string input = "****wa\n****we\n****wi\n";
    var output = string.Join(separator,
                             input.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(line => line.Substring(2)));
