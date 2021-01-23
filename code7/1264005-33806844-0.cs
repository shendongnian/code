    var qry = _liste.AsQueryable().OrderBy(listeCritere.SelectedValue)
        .GroupBy(listeCritere.SelectedValue, "It", null);
    foreach (IGrouping<object, Personne> item in qry)
    {
        Response.Write(item.Key + "<br/>");
        foreach (Personne p in item)
        {
            Response.Write("&nbsp;&nbsp;&nbsp;&nbsp; Nom complet : " + p._NOM + "<br/>");
        }
    }
