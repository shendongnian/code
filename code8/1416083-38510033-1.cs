    public static void CheckResolution(string imagePath)
    {      
        // Flag becomes true if the resize operation completes
        bool resizeCompleted = false;
        Image newImage = null;          
        // If file doesn't exist the code below returns null.
        var image = LoadSigleImageFromFile(imagePath);
        if(image == null) return;
        var baseArea = 2600 * 1000;//dimenzioni in risoluzione 
        using(FileStream stream = new FileStream(image.FileInfo.FullName, FileMode.Open, FileAccess.ReadWrite))
        {
            try
            {
                Image img = Image.FromStream(stream);
                var imageArea = img.Height * img.Width;
                if (imageArea >= baseArea)
                {
                    ... resize ops ....
                    // if (File.Exists(imagePath))
                          //File.Delete(imagePath);
                    // newImage.Save(imagePath, ImageFormat.Jpeg);
                    // Set the flag to true if resize completes
                    resizeCompleted = true;
               }
            }
            catch (Exception ex)
            {
                logger.Error("errore scala foto : " + ex.Message);
                throw new Exception("CheckResolution errore scala foto : " + ex.Message);
            }
        }
        // Now you can delete and save....
        if(resizeCompleted)
        {
            // No need to check for existance. File.Delete doesn't throw if
            // the file doesn't exist
            File.Delete(imagePath);
            newImage.Save(imagePath, ImageFormat.Jpeg);
        }
    }
    public static ImageFromFile LoadSigleImageFromFile(string file)
    {
        // Check if the file exists otherwise return null....
        var ris = null;
        if(File.Exists(file))
        {
            FileInfo fileInfo = new FileInfo(file);
            if (fileInfo.Name != "Thumbs.db")
               ris = (new ImageFromFile() { FileInfo = fileInfo });
        }
        return ris;
    }
