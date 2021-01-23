    class myBitmap : Bitmap
    {
      public myBitmap (string image) : base (image)   //so the Bitmap will get the file name it needs
      {
        imageFileName = image;  //remember for later.
      }
      public string imageFileName {get; set;}
    }
