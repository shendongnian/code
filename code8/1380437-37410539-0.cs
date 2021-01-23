                OracleCommand query = db.CreateCommand();
            query.CommandText = string.Format("insert into " + 
                ConfigurationManager.AppSettings.Get("usersTableName") +
                " values(null, :login, :pwd, 0, null)");
            query.Parameters.Add(":login", login);
            query.Parameters.Add(":pwd", HashPassword(pwd));
            bool isCreated = (query.ExecuteReader().RecordsAffected > 0 ? true : false);
    
