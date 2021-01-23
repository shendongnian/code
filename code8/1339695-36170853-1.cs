    {
        
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Names(Name) VALUES(@Name)"))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Name", txtDynamic.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
      
    }
