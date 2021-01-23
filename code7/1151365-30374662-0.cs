        public ImageSource selectedImage
                {
    ImageSource temp;
                    get{
                        if (selected)
                        {
                              temp=new BitmapImage(new Uri("ms-appx:////Assets/ic_selected.png", UriKind.RelativeOrAbsolute)); 
                            return temp ;
                        }
                        else
                        {
    temp=new BitmapImage(new Uri("/Assets/ic_not_selected.png", UriKind.RelativeOrAbsolute));
                            return temp ;
                        }
                    }
        
                }
        
