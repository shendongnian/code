    pictureBox1.Image = GetImage(Properties.Settings.Default.MyImage);
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
