    var wantedCombinations = new List<dynamic>
    {
        new { Symbol1 = "a", Symbol2 = "b" },
        new { Symbol1 = "a", Symbol2 = "c" }
    };
    
    var result = pairList.Where(pair => pair.Item1.Date == Beginday &&
                                        wantedCombinations.Any(item => item.Symbol1 == pair.Item1.Symbol &&
                                                          item.Symbol2 == pair.Item2.Symbol))
                         .Select(pair => new { Item = pair, Volspread = Math.Abs(pair.Item1.Vol - pair.Item2.Vol) })
                         .OrderBy(o => o.Volspread)
                         .Take(FirstSelect)
                         .Select(item =>item.Item)
                         .ToList();
