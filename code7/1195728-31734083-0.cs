     public static string GetCharacterRepetitionAndPosition(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return s;
            var result = (from ch in s
                          group ch by ch into g
                          select new { Cnt = g.Count(), Ch = g.Key }).OrderByDescending(a => a.Cnt).First();
            var idx = s.IndexOf(result.Ch);
            return new string(result.Ch, result.Cnt) + "," + idx;
        }
