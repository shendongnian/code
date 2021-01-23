    var matchedLines = new List<string>();
    foreach (string line in lines) {
        if (Regex.IsMatch(line, @"super awesome regex")) {
            matchedLines.Add(line);
        }
    }
