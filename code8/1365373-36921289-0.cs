    private void Update_Button_Click(object sender, EventArgs e)
    {
        // Build your connection
        using(var connection = new SqlCeConnection("{your-connection-string}"))
        {
             // Build your query
             var query = "UPDATE Contact_List SET ID = @Id, Name = @Name, Adress1 = @Adress1, Adress2 = @Adress2, City = @City, Province = @Province, Postal_Code = @Postal_Code, Phone = @Phone, Email = @Email WHERE ID = @Id";
             // If you want to append another OR statement for your WHERE clause, you could
             // do so here
             if(condition)
             {
                 query += " OR Property = @Property";
             }
             // Build your command to execute 
             using(var cmd = new SqlCeCommand(query,conn))
             {
                  conn.Open();
                  // Add all of your parameters
                  cmd.Parameters.AddWithValue("@Id", Id_Box.Text);
                  cmd.Parameters.AddWithValue("@Name",Name_Box.Text);
                  
                  // Tons of others omitted for brevity
                 
                  // Check for your other WHERE condition property
                  if(condition)
                  {
                        // Add your parameter to match your clause
                        cmd.Parameters.AddWithValue("@Property","{your-value}");
                  }
                  // Do your thing here
                  using(var reader = cmd.ExecuteReader())
                  {
                        // Omitted for brevity
                  }
             }
        }
    }   
