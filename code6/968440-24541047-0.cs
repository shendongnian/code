    protected override string CleanDataLine(string line)
    {
        //the regular expression for GlobalSight log
        Regex regex = new Regex("\".+\"");
        Match match = regex.Match(line);
        if (match.Success)
        {
            string matchPart = match.Value;
            matchPart = 
                  matchPart.Replace(string.Format("\"{0}\"", 
                  Delimiter), string.Format("\"{0}\"", "*+*+"));
            matchPart = matchPart.Replace(Delimiter, '_');
            matchPart = 
                  matchPart.Replace(string.Format("\"{0}\"", "*+*+"), 
                  string.Format("\"{0}\"", Delimiter));
            line = line.Replace(match.Value, matchPart);
        }
        return line;
    }
