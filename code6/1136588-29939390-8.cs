    var result = sortedHistos.GroupAdjacent(h => h.Commentaries)
                             .Select(g => new HistoMesure {
                                  Debut = g.Min(h => h.Debut),
                                  Fin = g.Max(h => h.Fin),
                                  Commentaries = g.Key
                              });
