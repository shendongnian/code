    public ActionResult Projet_Read([DataSourceRequest]DataSourceRequest request)
            {
                var projets = (from a in db.Projets
                              join b in db.Utilisateurs on a.UtilisateurID equals b.UtilisateurID
                              select new 
                              { 
                                  ProjetId=a.ProjetId,
                                  nomP=a.nomP,
                                  DateDebut=a.DateDebut,
                                  DateFinPrevue=a.DateFinPrevue,
                                  DateFinReele=a.DateFinReele,
                                  etat=a.etat,
                                  Description=a.Description,
                                  U=b.Prenom +" "+ b.nom
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
                    U=projet1.U,
                });
                 return Json(result);
            }
