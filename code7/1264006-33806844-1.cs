    var qry = _liste.AsQueryable().OrderBy(listeCritere.SelectedValue)
        .GroupBy(listeCritere.SelectedValue, "It", null);
    foreach (IEnumerable<Personne> item in qry)
    {
        if (item is IGrouping<DateTime, Personne>)
            Response.Write(((IGrouping<DateTime, Personne>)item).Key + "<br/>");
        else if (item is IGrouping<object, Personne>)
            Response.Write(((IGrouping<object, Personne>)item).Key + "<br/>");
        foreach (Personne p in item)
        {
            Response.Write("&nbsp;&nbsp;&nbsp;&nbsp; Nom complet : " + p._NOM + "<br/>");
        }
    }
