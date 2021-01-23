    using (SqlConnection conn = new SqlConnection())
                {
     try
      {
    conn.ConnectionString = "data source=yourserver;User ID=userid;Password=password;initial catalog=database;integrated security=False;MultipleActiveResultSets=True;App=EntityFramework";
       conn.Open();
    
      SqlCommand cmd = new SqlCommand("your sql query here", conn);
      SqlDataReader rd = cmd.ExecuteReader();
      cmb_company.Items.Add("3-All");
     while (rd.Read())
      {
       cmb_company.Items.Add(rd.GetValue(0)+"-"+rd.GetValue(1));
      //if you need to show both id and company name
    
       }
    rd.Close();
    conn.close();
    }
    catch(exception ex)
    {
    }
    }
