     public static ImageSource GetImageSourceFromPath(string path)
         {
             return new BitmapImage(new Uri(path));
         }
        
        Image_Control.Source = GetImageSourceFromPath(path);
