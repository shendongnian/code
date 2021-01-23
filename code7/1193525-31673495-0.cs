        string str = "Data Source=(LocalDB)\\v11.0;Database=Visual Studio 2012\\App_Data\\Database.mdf;Integrated Security=True";
        
        using(SqlConnection conn = new SqlConnection(str));
        {
           conn.Open();
           using(SqlCommand cmd = new SqlCommand("select * from user_login ",conn);
           { 
        
               SqlDataReader rdr = cmd.ExecuteReader();
    
               GridView1.DataSource = rdr;
               GridView1.DataBind();
            }
         conn.Close();
      }
