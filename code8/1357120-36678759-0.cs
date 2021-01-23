         protected DataTable dt = new DataTable()
         private void BindData()
         {
    
            using (SqlConnection con = new SqlConnection(cn))
            {
                using (SqlCommand cmd = new SqlCommand("usp_NewsByCategories"))
                {
    
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
    
                        sda.Fill(dt);
                       }
                }
            }
        }
