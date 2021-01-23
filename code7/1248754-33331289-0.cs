    using(var cn = new MySqlConnection(VarribleKeeper.MySQLConnectionString))
    using(var Command = cn.CreateCommand())
    {
       Command.CommandText = @"UPDATE TeleworksStats SET Ja = @Ja 
                               WHERE Brugernavn = @Brugernavn  AND Dato = @Dato";
       Command.Parameters.Add("@Ja", MySqlDbType.VarChar).Value = JaTak;
       Command.Parameters.Add("@Ja", MySqlDbType.VarChar).Value = VarribleKeeper.Brugernavn;
       Command.Parameters.Add("@Ja", MySqlDbType.DateTime).Value = DateTime.Today;
       // I assumed your column types. You should write proper column types instead.
       cn.Open();
       Command.ExecuteNonQuery();
    }
