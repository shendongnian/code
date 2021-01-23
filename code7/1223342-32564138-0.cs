    using (Image image = Image.FromStream(FileUpload1.PostedFile.InputStream))
    {                 
        using (MemoryStream m = new MemoryStream())
        {
            image.Save(m, image.RawFormat);
            byte[] imageBytes = m.ToArray();
            // Convert byte[] to Base64 String
            string base64String = Convert.ToBase64String(imageBytes);
            //Now save the base64String in your database
        }                  
    }
