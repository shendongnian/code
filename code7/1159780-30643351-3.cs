    string HouseId = Request.Params["HouseId"].ToString();
    
    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
        using (SqlCommand command = new SqlCommand("SELECT Id, Name, Townland, Near, Status, Built, Description, Families FROM Houses WHERE Id = " + HouseId + " ORDER BY Name DESC", connection))
        {
             connection.Open();
             using (SqlDataReader reader = command.ExecuteReader())
             {
                  while (reader.Read())
                  {
                      lblId.Text = reader[0].ToString();
                      lblName.Text = reader[1].ToString();
                      lblTown.Text = reader[2].ToString();
                      lblNear.Text = reader[3].ToString();
                      lblStatus.Text = reader[4].ToString();
                      lblBuilt.Text = reader[5].ToString();
                      lblDesc.Text = reader[6].ToString();
                      lblFam.Text = reader[7].ToString();
                  }
             }
        }
    }   
