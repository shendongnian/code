    protected void ClientSearch(object sender, EventArgs e)
    {
        using(var con = new SqlConnection("{your-connection-string}"))
        {
            var query = "SELECT * FROM Cliente WHERE nome = @name AND apelido = @apelido";
            using(var comm = new SqlCommand(query,con))
            {
                 con.Open();
                 // User parameters to avoid SQL Injection
                 comm.Parameters.AddWithValue("@name",textboxclientname.Text);
                 comm.Parameters.AddWithValue("@apelido",textboxapelido.Text);
                 // Get your result and store it in the Session
                 var id = -1;
                 Int32.TryParse(Convert.ToString(comm.ExecuteScalar()),out id);
                 if(id != -1)
                 {
                      // Store your ID in the Session
                      Session["UserID"] = id;
                      // Go to your other page
                      Response.Redirect("OtherPage.aspx");
                 }
                 else
                 {
                      // No user was found, do something
                 }
            }
        } 
    }
