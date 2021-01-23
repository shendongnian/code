    if(lstEnsemble.Items.Count == 0)
    {
        string sql = @"SELECT nomCli, prenomCli, appareil, villeCli, rueCli,
                       cpCli, telCli, description, dateEntree, mailCli
                       FROM client LEFT JOIN Panne ON (client.idClient = Panne.idClient)";
        MySqlConnection connexion = OpenConnection();
        MySqlCommand request = new MySqlCommand(sql, connexion);
        MySqlDataReader resultat = requestExecuteReader();
        while (resultat.Read())
        {
            ListViewItem item = new ListViewItem(resultat["nomCli"].ToString());
            item.SubItems.Add(resultat["prenomCli"].ToString());
            item.SubItems.Add(resultat["appareil"].ToString());
            item.SubItems.Add(resultat["villeCli"] + " " + resultat["cpCli"] + " " + resultat["rueCli"]);
            item.SubItems.Add(resultat["telCli"].ToString());
            item.SubItems.Add(resultat["description"].ToString());
            item.SubItems.Add(resultat["dateEntree"].ToString());
            item.SubItems.Add(resultat["mailCli"].ToString());
            lstEnsemble.Items.Add(item);
        }
        CloseConnection(connexion);
    }
