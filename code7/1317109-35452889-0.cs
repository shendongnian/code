    byte[] img_byte = null;
    long imgfilelength = 0;
    private void StoreImage(string ChosenFile)
    {
        try { 
            using (Image img = Image.FromFile(ChosenFile))
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                imgfilelength = ms.Length;
                img_byte = new byte[imgfilelength];
                ms.Read(img_byte, 0, img_byte.Length);
            }
        } catch (Exception e) { MessageBox.Show(e.ToString()); }
    }
