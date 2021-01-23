    List<string> myList = new List<string>();
    MatchCollection matches = Regex.Matches(<input string here>, @"(?<=\*\*)[A-Za-z0-9]+(?=\*\*)");
    for (int i = 0; i < matches.Count; i += 2)
    {
        myList.Add(matches[i].Value);
    }
