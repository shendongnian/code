    public Image Base64ToImage(string base64String)
    {
        var imageBytes = Convert.FromBase64String(base64String);
        using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
        {
            var image = Image.FromStream(ms, true);
            return image;
        }
    }
