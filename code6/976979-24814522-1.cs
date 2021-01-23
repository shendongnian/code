    Read a Image file:
    Bitmap loadedBitmap = Bitmap.FromFile(dialog.Filename);
    Image imgFile = Image.FromFile(dialog.Filename);
    
    
    using (MemoryStream ms = new MemoryStream())
      {
        // Convert Image to byte[]
        image.Save(ms, format);
        byte[] imageBytes = ms.ToArray();
    
        // Convert byte[] to Base64 String
        string base64String = Convert.ToBase64String(imageBytes);
        text2.Text = base64String;
      }
