    var image = GetImage("yourBase64String");
    public Image GetImage(string value)
    {        
        byte[] bytes = Convert.FromBase64String(value);
        Image image;
        using (MemoryStream ms = new MemoryStream(bytes))
        {
            image = Image.FromStream(ms);
        }
        return image;
    }
