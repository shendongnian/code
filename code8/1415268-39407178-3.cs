    private void WriteEntry(ODataEntry entry)
    {
        string file = @"C:\test.jpg";
        byte[] data = File.ReadAllBytes(file);  
        using (MemoryStream fileStream = new MemoryStream(data))
        using (Image i = Image.FromStream(originalms))
        {
           i.Save(this.context.Writer, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
