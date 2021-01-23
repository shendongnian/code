    var wantedCombinations = new List<dynamic>
    {
        new { Symbol1 = "a", Symbol2 = "b" },
        new { Symbol1 = "a", Symbol2 = "c" }
    };
    var result = (from pair in pairList
                 where pait.Item1.Date.Equals(Beginday)
                 join c in wantedCombinations on new { pair.Item1.Symbol, pair.Item2.Symbol } equls new { c.Symbol1, c.Symbol2 }
                 orderby Math.Abs(pair.Item1.Vol - pair.Item2.Vol)
                 select pair).Take(FirstSelect);
