     using (var cmd = new SQLiteCommand(conn))
            {
            using (var transaction = conn.BeginTransaction())
                    {            
                        for (var i = 0; i < 1000; i++)
                        {
    //Add your query here.
                            cmd.CommandText = "INSERT INTO TABLE (Field1,Field2) VALUES ('A', 'B');";
                            cmd.ExecuteNonQuery();
                        } 
                        transaction.Commit();
                    }
        }
