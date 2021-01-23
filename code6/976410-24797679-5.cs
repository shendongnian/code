     public void SaveImage(string filename, ImageFormat format) {
    
        WebClient client = new WebClient();
        Stream stream = client.OpenRead(imageUrl);
        Bitmap bitmap;  bitmap = new Bitmap(stream);
        if (bitmap != null) 
          bitmap.Save(filename, format);
        
        stream.Flush();
        stream.Close();
        client.Dispose();
    }
   
