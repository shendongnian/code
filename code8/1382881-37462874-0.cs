    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["type"] == "clients")
        {
                List<Client> clients=new List<Client>();
                // SQL Server Read Statement Sample
                using (SqlConnection conn = new SqlConnection(Gizmos.getConnectionString()))
            {
                SqlCommand command = new SqlCommand("select * from clients", conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Client Client = new Client();
                        Client.name = reader["name"].ToString();
                        Client.company = reader["company"].ToString();
                        clients.Add(Client);
                        //string jsonString =                     JsonConvert.SerializeObject(Client);
                        
                    }
                }
            }
          var jsonString = JsonConvert.SerializeObject(clients);
          Response.Write(jsonString);
        Response.End();
        }//end if Clients
    }
