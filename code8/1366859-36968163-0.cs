    SqlCommand command = new SqlCommand("select * from button_properties", con);
    con.Open();
    using(SqlDataReader read = command.ExecuteReader())
    {
        while(read.Read())
        {
            Button dynamicButton = new Button();
        
            dynamicButton.Height = (read["height"].ToString());
            dynamicButton.Width = (read["width"].ToString());
            dynamicButton.Text = (read["text"].ToString());
            dynamicButton.Name = (read["name"].ToString());
            dynamicButton.Location = new Point(20, 150);
        
            Controls.Add(dynamicButton);
        }
    }
