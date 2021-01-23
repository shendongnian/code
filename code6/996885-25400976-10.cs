    public byte[] ImageToByteArray(System.Drawing.Image imageIn)
    {
        using(var ms = new MemoryStream())
        {
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        
            return ms.ToArray();
        }
    }
    
    public Image ByteArrayToImage(byte[] byteArrayIn)
    {
         using(var ms = new MemoryStream(byteArrayIn))
         {
             var returnImage = Image.FromStream(ms);
    
             return returnImage;
         }
    }
