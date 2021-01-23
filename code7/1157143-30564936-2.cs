    class myBitmap
    {
      Bitmap theBitmap;
      public myBitmap (string image)
      {
        imageFileName = image;  //remember for later.
        theBitmap = new Bitmap(image);
      }
      public string imageFileName {get; set;}
    }
