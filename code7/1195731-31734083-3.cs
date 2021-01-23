     public static string GetCharacterRepetitionAndPosition(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return s;
            var result = (from ch in s
                          group ch by ch into g
                          select new { Cnt = g.Count(), Ch = g.Key });
            var maxCnt = -1;
            char theMaxChar =char.MinValue;
            int howManyCharacters;
            foreach (var item in result)
            {
                if (item.Cnt > maxCnt)
                {
                    maxCnt = item.Cnt;
                    theMaxChar = item.Ch;
                    howManyCharacters = item.Cnt;
                }
            }
            var idx = s.IndexOf(theMaxChar);
            return new string(theMaxChar,maxCnt) + "," + idx;
        }
