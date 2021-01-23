    using (var con = new SqlConnection(conString))
    using(var cmd = con.CreateCommand())
    {
         cmd.CommandText = @"UPDATE moviemaster 
                             SET Runtime = @runtime, DateMasterId = @dateid, Trailer = @trailer, Synopsis = @synopsis
                             WHERE MovieMasterId = @movieid";
         cmd.Parameters.Add("@runtime", MySqlDbType.VarChar).Value = runtime; ;
         cmd.Parameters.Add("@dateid", MySqlDbType.VarChar).Value = dateid;
         cmd.Parameters.Add("@trailer", MySqlDbType.VarChar).Value = trailer;
         cmd.Parameters.Add("@synopsis", MySqlDbType.VarChar).Value = synopsis;
         cmd.Parameters.Add("@movieid", MySqlDbType.VarChar).Value = movieid;
         // I assumed your column types are VarChar.
         con.Open();
         cmd.ExecuteNonQuery();
    }
