    List<Score> scores = new List<Score>();
<!-- -->
<!-- -->
    foreach (string entry in splitscores)
    {
        string replace = entry.Replace("[", "").Replace("]", "");
        string[] splitentry = replace.Split('-');
    
        if (splitentry.Count() > 1)
        {
            scores.Add(new Score(splitentry[0], Int32.Parse(splitentry[1]))
        }
    }
