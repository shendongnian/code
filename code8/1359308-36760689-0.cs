    public ActionResult Create(FormCollection form)
            {
                Projet projet = new Projet();
                int x=Convert.ToInt32(TempData.Peek("x").ToString());
                projet.UtilisateurID = x;
                string name = form["nom"].ToString();
                var n = (from p in db.Projets
                         where (p.nomP.Equals(name))
                         select p).FirstOrDefault();
                if (n != null)
                    ViewBag.NomExiste = "Ce Nom De Projet Existe Déjà!";
                else
                {
                    projet.nomP = form["nom"];
                    if (form["DateDebut"].Trim().Length != 0)
                    {
                        string s = form["DateDebut"];
                        DateTime DateDebut1 = DateTime.ParseExact(s, "M/d/yyyy", CultureInfo.InvariantCulture);
                        projet.DateDebut = DateDebut1;
                    };
                    if (form["DateFinPrevue"].Trim().Length != 0)
                    {
                        string s = form["DateFinPrevue"];
                        DateTime DateFinPrevue1 = DateTime.ParseExact(s, "M/d/yyyy", CultureInfo.InvariantCulture);
                        projet.DateFinPrevue = DateFinPrevue1;
                    };
                    projet.DateFinReele = null;
                    if (form["DateFinReele"].Trim().Length != 0)
                    {
                        string s = form["DateFinReele"];
                        DateTime DateFinReele1 = DateTime.ParseExact(s, "M/d/yyyy", CultureInfo.InvariantCulture);
                        projet.DateFinReele = DateFinReele1;
                    };
                    projet.Description = form["Description"];
                    projet.etat = form["etat"];
                    if (ModelState.IsValid)
                    {
                        db.Projets.Add(projet);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    };
                };
                return View(projet);
            }
