    public static void CheckResolution(string imagePath)
    {      
        bool resizeCompleted = false;
        Image newImage = null;          
        var image = LoadSigleImageFromFile(imagePath);
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
                    resizeCompleted = true;
               }
            }
            catch (Exception ex)
            {
                logger.Error("errore scala foto : " + ex.Message);
                throw new Exception("CheckResolution errore scala foto : " + ex.Message);
            }
        }
        if(resizeCompleted)
        {
            if (File.Exists(imagePath)) File.Delete(imagePath);
            newImage.Save(imagePath, ImageFormat.Jpeg);
        }
    }
