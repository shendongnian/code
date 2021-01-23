    using(var con = new MySqlConnection(conString))
    using(var cmd = con.CreateCommand())
    {
         cmd.CommandText = "UPDATE `doTable` SET  Active = @active WHERE ID = @id";
         cmd.Parameters.Add("@active", MySqlDbType.VarChar).Value = Active.ToString();
         cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = ID.ToString();
         // I assumed your columns are VarChar type.
         con.Open();
         cmd.ExecuteNonQuery();
    }
