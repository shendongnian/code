    public ImageSource imageSourceForImageControl
    {
      get
       {
         ImageSourceConverter c = new ImageSourceConverter();
         return (ImageSource)c.ConvertFrom(yourBitmap);
       }
    }
