    using(SqlConnection con = new SqlConnection("connection string"))
    {
        int nX = 0;
        int nY = 0;
            
        con.Open();
    
        using(SqlCommand cmd = new SqlCommand("SELECT * FROM SomeTable", connection))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        //create buttons
                        Button newButton = new Button();
                            
                       // now set the DB properties
                       newButton.Text = reader.GetString(0): // or whatever
                       
                       // now calculate the X and Y coordinates
                       nX += 25;
                       newButton.Location = new Point(nX,nY);
                       
                       // add new button
                       this.Controls.Add(newButton);  
                    }
                }
            } // reader closed and disposed up here
    
        } // command disposed here
    
    } //connection closed and disposed here
