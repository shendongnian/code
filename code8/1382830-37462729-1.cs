        string query = "SELECT * FROM gebruiker WHERE id='" + id + "'";
        List<string> listGebruiker = new List<string>();
        if (this.openConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Een nieuw datareader object maken en dan query uitvoeren
            MySqlDataReader dataReader = cmd.ExecuteReader();
            
            while (dataReader.Read())
            {
                listGebruiker.Add(dataReader["id"].ToString());
                listGebruiker.Add(dataReader["voornaam"].ToString());
                listGebruiker.Add(dataReader["achternaam"].ToString());
                listGebruiker.Add(dataReader["geboortedatum"].ToString());
                listGebruiker.Add(dataReader["Rol_id"].ToString());
            }
            
            dataReader.Close();
            this.closeConnection();
            return list;
        }
