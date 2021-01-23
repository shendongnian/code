        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
          using (MemoryStream ms = new MemoryStream())
          {
        // Convert Image to byte[]
        image.Save(ms, format);
        byte[] imageBytes = ms.ToArray();
    
        // Convert byte[] to Base64 String
        string base64String = Convert.ToBase64String(imageBytes);
        return base64String;
      }
    }
