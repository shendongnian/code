    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
    using (SqlConnection con = new SqlConnection(CS))
    {
          try
          {
               con.Open();
               SqlCommand command = new SqlCommand("select * from [dbo].[employee]", con);
               SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
               GridView1.DataSource = reader;
               GridView1.DataBind();
           }
           catch
           {
             //Handle error
           }
    }
