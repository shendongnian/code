    var result = from h in sortedHistos
                 group h by h.Commentaires into g
                 select new HistoMesure {
                     Debut = g.First().Debut, // thus you have sorted entries
                     Fin = g.Last().Fin,
                     Commentaires = g.Key
                 };
