    byte[] GetLogoBytes(HtmlInputFile logoPrvw)
    {
        if (logoPrvw.Value == null)
        {
            return null; // Or an empty array, or whatever
        }
        using (Image img = Image.FromFile(logoPrvw.Value))
        {
            using (MemoryStream ms = new MemoryStream())
            {
               img.Save(ms, ImageFormat.Jpeg);
               return ms.ToArray();
            }
        }
    }
