    public static IEnumerable<System.Text.RegularExpressions.Match> AsEnumerable(this System.Text.RegularExpressions.MatchCollection mc)
    {
        foreach (System.Text.RegularExpressions.Match m in mc)
        {
            yield return m;
        }
    }
