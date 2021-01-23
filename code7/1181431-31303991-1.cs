    public Image ByteArrayToImage(byte[] byteArrayIn)
    {
        using (MemoryStream ms = new MemoryStream(byteArrayIn))
        using (Image returnImage = Image.FromStream(ms))
        {
            return returnImage.Clone();
        }
    }
