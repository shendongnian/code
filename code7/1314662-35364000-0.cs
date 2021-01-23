    private Rule MatchRule(string cond)
    {
        var results = (from x in rules
                      where x.Cond == cond
                      group x by new { x.Tree.Val , r = x.Tree.Right.Val, l = x.Tree.Left.Val} 
                      into g
                      select new {
                         rule = g.First(),
                          Count=g.Count(), 
                      }).OrderByDescending(x => x.Count).ToList();
        return results[0].rule;
    }
