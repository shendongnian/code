    ClickableImage : Image 
    {
          public ClickableImage()
          {
               Tapped += (sender, e) => 
               {
                     System.Diagnostics.Debug.WriteLine("Image clicked!");
               };
          }
    }
