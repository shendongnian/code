    string[] splitBySpace = line.Split(' ');
    string pattern = @"[^0-9\.\,]+";
    
    string first = splitBySpace.ElementAt(0);
    string last = (new Regex(pattern)).Split(splitBySpace.ElementAt(splitBySpace.Length - 1))
                                        .FirstOrDefault();
    
    decimal lastDecimal;
    bool success = decimal.TryParse(last, out lastDecimal);
