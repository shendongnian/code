    // Construct the automaton
    AhoCorasickStringSearcher matcher = new AhoCorasickStringSearcher();
    foreach (var searchWord in File.ReadLines(File_a)
    {
        matcher.AddItem(searchWord);
    }
    matcher.CreateFailureFunction();
    // And then do the search on each file
    foreach (var fileName in listOfFiles)
    {
        foreach (var line in File.ReadLines(filename))
        {
            var matches = matcher.Search(line);
            foreach (m in matches)
            {
                // output match
            }
        }
    }
