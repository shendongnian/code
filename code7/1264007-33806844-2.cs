    public void ButtonClickHandler(object sender, EventArgs e)
    {
        var qry = _liste.AsQueryable().OrderBy(listeCritere.SelectedValue)
            .GroupBy(listeCritere.SelectedValue, "It", null);
        if (listeCritere.SelectedValue == "_DDN")
            WritePersonneResponse<DateTime>(Response, qry);
        else
            WritePersonneResponse<string>(Response, qry);
    }
    public void WritePersonneResponse<T>(HttpResponse response, IQueryable qry)
    {
        foreach (IGrouping<T, Personne> item in qry)
        {
            response.Write(item.Key + "<br/>");
            foreach (Personne p in item)
            {
                response.Write("&nbsp;&nbsp;&nbsp;&nbsp; Nom complet : " + p._NOM + "<br/>");
            }
        }
    }
