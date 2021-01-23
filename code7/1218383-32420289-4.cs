    public byte[] imageToByteArray(System.Drawing.Image imageIn)
    {
        MemoryStream ms = new MemoryStream();
        imageIn.Save(ms,System.Drawing.Imaging.ImageFormat.Gif);
        return  ms.ToArray();
    }
    public Image byteArrayToImage(byte[] byteArrayIn)
    {
         MemoryStream ms = new MemoryStream(byteArrayIn);
         Image returnImage = Image.FromStream(ms);
         return returnImage;
    }
