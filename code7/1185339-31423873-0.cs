            List<string> ids = new List<string>();
            using (SqlConnection conn = new SqlConnection("MyConnectionString"))
            {
                using (SqlCommand cmd = new SqlCommand("MyStoredProcedure", conn))
                {
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            ids.Add(rdr["NameOfIsField"].ToString());
                        }
                    }
                }
            }
            MyListBox.DataSource = ids;
