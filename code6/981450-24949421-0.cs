    using (var dbSqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString1"]))
    {             
           var cmd = new SqlCommand("Your_Sql_Command", con);
           dbSqlConnection.Open();  // is this required?
           cmd.ExecuteNonQuery();
    }
