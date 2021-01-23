    var groups = new List<string> {"ww1", "ww2", ...};
    var previousQuery = ... //(I'll assume a List<CountResult> but tuple would work the same)
    var finalList = previousQuery.Concat(
                        groups.Where(g => ! previousQuery.Exists(p => p.Ww == g))
                              .Select(g => new CountResult {Ww=g, Count=0})
                    );
