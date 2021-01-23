    var last5CommesseRisorsaPjId = db.Attivita
                       .Where(a => a.IdRisorsa == loggedUser.Id)
                       .GroupBy(a => a.FasiCommessa.Commesse.AxProjId)
                       .Select(g => new { AxProjId = g.Key, MaxData = g.Max(a => a.Data) })
                       .OrderByDescending(c => c.MaxData)
                       .Select(c => c.AxProjId)
                       .Take(5)
                       .ToList();
