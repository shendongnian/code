        public List<Parent> loaddataParent()
        {
            List<Parent> parent = new List<Parent>();
            SqlConnection conn = new SqlConnection(@"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=test;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("select * from testing where pid=0", conn);
            SqlDataReader dr;
            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    parent.Add(new Parent()
                    {
                        pID = dr.GetInt32(dr.GetOrdinal("id")),
                        pParentID = dr.GetInt32(dr.GetOrdinal("pid")),
                        pTitle = dr.GetString(dr.GetOrdinal("title"))
                    });
                }
                dr.Close();
            }
            catch (Exception exp)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return parent;
        }
