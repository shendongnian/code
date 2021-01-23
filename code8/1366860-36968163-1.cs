    SqlCommand command = new SqlCommand("select * from button_properties", con);
    con.Open();
    using(SqlDataReader read = command.ExecuteReader())
    {
        while(read.Read())
        {
            Button dynamicButton = new Button();
        
            dynamicButton.Height = (int)read["height"];
            dynamicButton.Width = (int)read["width"];
            dynamicButton.Text = read["text"].ToString();
            dynamicButton.Name = read["name"].ToString();
            dynamicButton.Location = new Point(20, 150);
        
            Controls.Add(dynamicButton);
        }
    }
