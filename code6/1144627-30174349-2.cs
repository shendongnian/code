    string connString = "Server=localhost;Port=3306;Database=rookstat;Uid=XXXXXXX;password=XXXXXX;";
    using(MySqlConnection conn = new MySqlConnection(connString))
    using(MySqlCommand command = conn.CreateCommand())
    {
        conn.Open();
        command.CommandText = @"Insert into rookstayers 
                 (id, name, sex,   vocation, level, achievements, 
                  world, lastlogin, accountstatus, onlinestatus) 
           values('', @name, @sex, @vocation, @level, @Achievements,
                  @World, @LastLogin, @AccountStatus, @OnlineStatus)";
        command.Parameters.Add("@name", MySqlDbType.VarChar);
        command.Parameters.Add("@sex", MySqlDbType.VarChar);
        command.Parameters.Add("@vocation", MySqlDbType.VarChar);
        command.Parameters.Add("@level", MySqlDbType.Int32);
        .... and so on for all the parameters placeholders
        foreach (Player rooker in Players)
        {
              command.Parameters["@name"].Value = rooker.Name;
              command.Parameters["@sex"].Value = rooker.Sex;
              command.Parameters["@vocation"].Value = rooker.Vocation;
              command.Parameters["@level"].Value = rooker.Level;
              
              ... and so on for the other parameters defined
              command.ExecuteNonQuery();
        }
    }
