    string pattern = @"\[(?:([^,\]]+),?\s*)+\]";
    var re = new Regex( pattern);
    var text = @".xxx[val1, val2, val3]";
    
    
    MatchCollection matches = re.Matches(text);
    for (int mnum = 0; mnum < matches.Count; mnum++)
    {   //loop matches
        Match match = matches[mnum];
        Console.WriteLine("Match #{0} - Value: {1}", mnum + 1, match.Value);
        int captureCtr = 0;
        foreach (Capture capture in match.Groups[1].Captures)
        {  //loop captures for the 1st Group
           Console.WriteLine("      Capture {0}: {1}", 
                             captureCtr, capture.Value);
           captureCtr += 1;                  
        }
    }
