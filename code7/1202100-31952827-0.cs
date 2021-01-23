     foreach (ReviewTripDC ReviewTrip in ReviewTripsByPreTripIds)
      {
          ImageButton imageButton = new ImageButton();
          imageButton.ImageUrl = "~/" +ReviewTrip.CorridorName+"/"+ReviewTrip.Time+"/"+ReviewTrip.ImgFileName;
          imageButton.Height = Unit.Pixel(100);
          imageButton.Style.Add("padding", "5px");
          imageButton.Width = Unit.Pixel(100);
          imageButton.Click += new ImageClickEventHandler((a, b) => imageButton_Click(a, b, ReviewTrip));
          AMSPanel1.Controls.Add(imageButton);
          AMSPanel1.Height = Unit.Pixel(860);
      }
    
      protected void imageButton_Click(object sender, ImageClickEventArgs e, ReviewTripDC ReviewTrip)
      {
          testimage.ImageUrl = ((ImageButton)sender).ImageUrl;
          lblTime.Text = ReviewTrip.Time; 
          lblLocation.Text = ReviewTrip.Location; //I can access review trip object here now
      }    
