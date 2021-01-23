    public IEnumerable<string> MethodX(string[] text)
    {
        foreach (var line in text)
        {
            var newLine = "";
            var ln = line.TrimStart(' ');
            var colon = line.IndexOf(":");
            if (colon != -1)
            {
            if (ln.StartsWith("adj")) newLine = "j 1" + line.Substring(colon);
                else if (ln.StartsWith("adv")) newLine = "d 1" + line.Substring(colon);
                else if (ln.StartsWith("n")) newLine = "n 1" + line.Substring(colon);
                else if (ln.StartsWith("v")) newLine = "v 1" + line.Substring(colon);
            }
            else
            {
                newLine = line;
            }
    
            yield return newLine.Trim();
        }
    }
