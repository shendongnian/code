    public Image BytesToImage(byte[] byteArray)
    {    
        using (var ms = new MemoryStream(byteArray))
        {
            return Image.FromStream(ms);
        }
    }
