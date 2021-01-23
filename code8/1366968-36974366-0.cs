    public Bitmap Base64ToImage(string base64String)
     {
        // Convert base 64 string to byte[]
        byte[] imageBytes = Convert.FromBase64String(base64String);
        // Convert byte[] to Image
        using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
        {
            Bitmap image = BitmapFactory.FromStream(ms, true);
            return image;
        }
     }
