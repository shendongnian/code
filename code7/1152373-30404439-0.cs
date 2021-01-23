    public void SaveResizedImage()
            {
                // if no file do nothing
                if (!uploadImage.HasFile) return;
                var file = uploadImage.PostedFile;
                var originalImage = Image.FromStream(file.InputStream);
                
                // enter width and height
                var resizedImage = new Bitmap(width, heigth);
                using (var g = Graphics.FromImage(result))
                g.DrawImage(bitmap, 0, 0, width, heigth);
                // it is better to save files with unique 
                //name rather saving  them with originals  
                resizedImage.Save(FolderPath + uploadedImage.FileName);
                
            }
    
