     using(SqliteConnection con = new SqliteConnection(cs))
            {
                con.Open();
    
                string stm = "SELECT ListItem FROM Table";
    
                using (SqliteCommand cmd = new SqliteCommand(stm, con))
                {
                    using (SqliteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read()) 
                        {
                            //add items to your list
                        }         
                    }
                }
    
                con.Close();   
             }
