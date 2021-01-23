    List<string> regexStrings = db.GetRegexStrings();
    var result = new List<Regex>(regexStrings.Count);
    foreach (var regexString in regexStrings)
    {
        result.Add(new Regex(regexString);
    }
    ...
    // The check
    bool matched = result.Any(i => i.IsMatch(testInput));
