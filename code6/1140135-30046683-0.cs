    Regex r = new Regex("Space(?<entry>[0-9]{1,3})", RegexOptions.ExplicitCapture);
    foreach (Match m in r.Matches("Space123"))
    {
        Group grp = m.Groups["entry"];
        int strt = r.ToString().IndexOf("(", grp.Index);
        int len = r.ToString().IndexOf(")", grp.Index + 1) - r.ToString().IndexOf("(", grp.Index) + 1;
         string groupThatMathced = r.ToString().Substring(strt, len);
    }
