    public Image ByteArrayToImage(byte[] byteArrayIn)
    {
        using (MemoryStream ms = new MemoryStream(byteArrayIn))
        {
            ms.Position = 0;
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
