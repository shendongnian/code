    foreach(RegexRule r in RegexRules.ToList())
    { 
        Regex rx = new Regex(r.Expression); 
        MatchCollection mc = rx.Matches(str); 
        foreach(Match m in mc.OfType<Match>().Distinct()) 
        { 
             MessageBox.Show("replacing");
             str = str.Replace(m.Groups[1].Value, 
                               r.OpenBBOne + m.Groups[1].Value + r.CloseBBOne);
        }
    }
