         string cs = "URI=file:test.db";        
        
        using (SqliteConnection con = new SqliteConnection(cs)) 
        {
            con.Open();
            using(SqliteTransaction tr = con.BeginTransaction())
            {
                using (SqliteCommand cmd = con.CreateCommand())
                {
                    cmd.Transaction = tr;
                    cmd.CommandText = "DROP TABLE IF EXISTS Friends";
                    cmd.ExecuteNonQuery();
                 ...............
                 }
                tr.Commit();
            }
            con.Close();
        }
    }
