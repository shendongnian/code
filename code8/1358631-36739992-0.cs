    public ActionResult Projet_Read([DataSourceRequest]DataSourceRequest request)
            {
                var projets = (from a in db.Projets
                              join b in db.Utilisateurs on a.UtilisateurID equals b.UtilisateurID
                              select new 
                              { 
                                  ProjetId = a.ProjetId,
                                  nomP = a.nomP,
                                  DateDebut = a.DateDebut,
                                  DateFinPrevue = a.DateFinPrevue,
                                  DateFinReele = a.DateFinReele,
                                  etat = a.etat,
                                  Description = a.Description,
                                  Prenom = b.Prenom,
                                  Nom = b.Nom
                              });
                DataSourceResult result = projets.ToDataSourceResult(request, projet1 => new
                {
                    ProjetId = projet1.ProjetId,
                    nomP = projet1.nomP,
                    DateDebut = projet1.DateDebut,
                    DateFinPrevue = projet1.DateFinPrevue,
                    DateFinReele = projet1.DateFinReele,
                    Description = projet1.Description,
                    etat = projet1.etat,
                    Prenom = projet1.Prenom,
                    Nom = projet1.Nom
                });
                 return Json(result);
            }
