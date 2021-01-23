    private async Task FindOtherBrands(string term, 
                                       Dictionary<int, Scoring> results, 
                                       CancellationToken cancellationToken)
    {
        MySqlCommand cmd;
        string requete;
        requete = "SELECT m.id, m.nom as label 
                   FROM marque m 
                   WHERE m.nom LIKE '" + term + "%'";
        cmd = new MySqlCommand(requete, conn);
        var Rd = await cmd.ExecuteReaderAsync();
        while (Rd != null && await Rd.ReadAsync())
        {
            cancellationToken.ThrowIfCancellationRequested();
            int id = int.Parse(Rd["id"].ToString());
            if (!results.ContainsKey(id))
            {
                results.Add(id, new Scoring()
                {
                    score = 100,
                    value = Rd["label"].ToString()
                });
            }
        }
        Rd.Close();
        requete = "SELECT m.id, m.nom as label 
                   FROM marque m 
                   WHERE m.nom LIKE '%" + term + "%'";
        cmd = new MySqlCommand(requete, conn);
        Rd = await Cmd.ExecuteReaderAsync();
        while (Rd != null && await Rd.ReadAsync())
        {
            cancellationToken.ThrowIfCancellationRequest();
            int id = int.Parse(Rd["id"].ToString());
            if (!results.ContainsKey(id))
            {
                results.Add(id, new Scoring()
                {
                    score = 10,
                    value = Rd["label"].ToString()
                });
            }
        }
        Rd.Close();
    }
