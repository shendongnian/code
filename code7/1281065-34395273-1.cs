    public static Image CreateIndexedImage(string path) 
    { 
        using (var sourceImage = (Bitmap)Image.FromFile(path)) 
        { 
            var targetImage = sourceImage.Clone; 
            
            // manipulate image 
            ...
      
            return targetImage;
        } 
    } 
