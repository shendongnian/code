         foreach (Tripclass Trip in TripsByTripIds )
      {
          ImageButton imageButton = new ImageButton();
          imageButton.ImageUrl = "~/" +Trip.CorridorName+"/"+Trip.Time+"/"+Trip.ImgFileName;
          imageButton.Height = Unit.Pixel(100);
          imageButton.Style.Add("padding", "5px");
          imageButton.Width = Unit.Pixel(100);
          imageButton.Click += new ImageClickEventHandler((a, b) => imageButton_Click(a, b, ReviewTrip));
          AMSPanel1.Controls.Add(imageButton);
          AMSPanel1.Height = Unit.Pixel(860);
      }
    
      protected void imageButton_Click(object sender, ImageClickEventArgs e, Tripclass Trip)
      {
          testimage.ImageUrl = ((ImageButton)sender).ImageUrl;
          lblTime.Text = Trip.Time; 
          lblLocation.Text = Trip.Location; //I can access trip object here
      }   
