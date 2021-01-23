    public ImageSource depImage;
    public ImageSource dependaImage 
    {
        get 
        {
            if( depImage == null )
				{
					depImage= new BitmapImage( new Uri( "character1.png", UriKind.Relative ) );
				}
				return depImage;
        } 
    }
