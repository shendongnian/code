    string ParseString(string Text)
    {
        Regex re = new Regex(@"\d+");
        Match m = re.Match(Text);
        if (m.Success && m.Index > 1)
        {
            return Text.Substring(m.Index - 2);
        }
        return "";
    }
