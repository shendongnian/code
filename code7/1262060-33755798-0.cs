    var liste = new List<Dictionary<string, string>>();
    foreach(var site in sitesList)
    {
        liste.Add(new Dictionary<string, string> { {site.Id.ToString(), site.RaisonSociale } } );
    }
    
    return Json(liste,
      JsonRequestBehavior.AllowGet);
