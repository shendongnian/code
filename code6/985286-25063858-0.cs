    protected bool SaveData(string FileName, byte[] Data)
    {
        using (Image image = Image.FromStream(new MemoryStream(Data)))
        {
            image.Save("MyImage.jpg", ImageFormat.Jpeg);
        }
        return true;
    }
