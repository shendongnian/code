    public object FileLocation
    {
        get
        {
            try
            {
                 return new BitmapImage(new Uri((string)PathToImage));
            }
            catch 
            {
                 return new BitmapImage();
            }
        }
    }
