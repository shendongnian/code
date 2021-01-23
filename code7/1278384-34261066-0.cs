    private void InsertData()
    {
      SqlConnection con = new  SqlConnection(ConfigurationManager.
      ConnectionStrings["kernelCS"].ConnectionString);
      SqlCommand cmd = new SqlCommand(@"INSERT INTO [tbl_Leads]
      ([CompanyName]) VALUES (@CompanyName)", con);
      cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text.ToString());
      
      con.Open();
      cmd.ExecuteNonQuery();
    }`
