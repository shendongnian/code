    public Image LoadImage()
    {
        //data:image/png;base64,
        byte[] bytes = Convert.FromBase64String(YOUR_BASE64_ENCODED_STRING);
        Image image;
        using (MemoryStream ms = new MemoryStream(bytes))
        {
            image = Image.FromStream(ms);
        }
        return image;
    }
