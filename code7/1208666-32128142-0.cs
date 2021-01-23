    if (reader.HasRows)
    {
       while (reader.Read())
       {
           // Create new image control
           var newImage = new Image ();
           newImage.ImageUrl = reader.GetString(0);
           newImage.Height = 100;
           newImage.Width = 100;
           // Add new image to panel
           Panel1.Controls.Add (newImage);
       }
    }
