    public ActionResult Nouvelle(string routeValue)
        {
            var sliders = db.Actualite.Where(a => a.Afficher).OrderByDescending(a => a.Date_publication);
            var partenaires = db.Partenaire.Where(p => p.Afficher);
            var nouvelle = db.Actualite.Where(a => a.Jeton /*this needs to be changed to the property that is doing the comparison*/ == routeValue).First();
            var model = new ModelNouvelle { Slider = sliders, Partenaire = partenaires, Nouvelle = nouvelle };
            return View(model);
        }
