     var last5CommesseRisorsaPjId = db.Attivita
                        .Where(a => a.IdRisorsa == loggedUser.Id)
                        .Distinct()
                        .OrderByDescending(a => a.Data)      //this looks ignored
                        .Select(a => a.FasiCommessa.Commesse.AxProjId)
                        .Take(5)
                        .ToList();
