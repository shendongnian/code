    using(var fromStream = GetSourceImageStream()) 
    { 
        try 
        {
          int newHeight = width * fromStream.Height / fromStream.Width;
    
          using(Image newImage = new Bitmap(width, newHeight))
          {
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
              graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
              graphicsHandle.DrawImage(fromStream, 0, 0, width, newHeight);
            }
            string processedFileName = String.Concat(Configuration.CoverLocalPath, @"\Processed\res_", Path.GetFileName(imageFile));
            newImage.Save(processedFileName, ImageFormat.Jpeg);
          }    
          return processedFileName; 
        } 
        catch (Exception ex) 
        {
           Configuration.Log.Debug("Utility.cs", "ResizeMainCover", ex.Message);
           return string.Empty; 
        }
        finally
        {
          fromStream.Close();
        } 
     }
