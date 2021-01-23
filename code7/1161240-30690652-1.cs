        string constr = ConfigurationManager.ConnectionStrings["My_DatabaseConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO TestTable1 VALUES (@FirstName,@Email,@DateTime)"))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@Email", user.Email);                    
                   cmd.Parameters.AddWithValue("@DateTime",System.DateTime.Now);                    
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        
