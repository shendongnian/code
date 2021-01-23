    foreach(RegexRule r in RegexRules.ToList())
    { 
        Regex rx = new Regex(r.Expression); 
        MatchCollection mc = rx.Matches(str);
        List<Match> matches = new List<Match>();
        List<string> strings = new List<string>();
        foreach(Match m in mc)
            if(!strings.Contains(m.Value))
            {
                matches.Add(m);
                strings.Add(m.Value);
            }
        foreach(Match m in matches) 
        { 
             MessageBox.Show("replacing");
             str = str.Replace(m.Groups[1].Value, 
                               r.OpenBBOne + m.Groups[1].Value + r.CloseBBOne);
        }
    }
