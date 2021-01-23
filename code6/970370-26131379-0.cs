    [SqlFunction(DataAccess = DataAccessKind.None, IsDeterministic = true, IsPrecise = true, Name = "RegExSplitIndex",
        SystemDataAccess = SystemDataAccessKind.None, FillRowMethodName = "RegExSplitIndexRow",
        TableDefinition =
            "Match NVARCHAR(MAX), MatchIndex INT, MatchLength INT, NextMatchIndex INT"
        )]
     public static IEnumerable RegExSplitIndex(SqlString input, SqlString pattern, SqlInt32 options)
    {
        if (input.IsNull || pattern.IsNull) return null;
        var matchcol = Regex.Matches(input.Value, pattern.Value, (RegexOptions)options.Value);
        var matches = matchcol.Cast<Match>().ToList().Select(MatchKeys.Translate).ToList();
        if (matches.Any() && matches.All(i => i.MatchIndex != 0))
        {
            var ix = matches.OrderBy(i => i.MatchIndex).First().MatchIndex;
            matches.Add(new MatchKeys() {MatchIndex = 0, MatchLength = 0, NextMatchIndex = ix});
           
        }
        return matches;
    }
    public static void RegExSplitIndexRow(Object input, ref SqlString match, ref SqlInt32 matchIndex, ref SqlInt32 matchLength, ref SqlInt32 nextMatchIndex)
    {
        MatchKeys m = (MatchKeys)input;
        match = new SqlString(m.Match);
        matchIndex = m.MatchIndex;
        matchLength = m.MatchLength;
        nextMatchIndex = m.NextMatchIndex;
    } 
