    private void ResizeImages(FileInfo[] files)
    {
        foreach (FileInfo file in files)
        {
            Image img = Image.FromFile(file.FullName);
            var newImage = ScaleImage(img, 200, 400);
    
            img.Dispose();
    
            newImage.Save(file.FullName);
        }   
    }
