    byte[] img_byte = null;
    long imgfilelength = 0;
    private void StoreImage(string ChosenFile)
    {
        try { 
            using (Image img = Image.FromFile(ChosenFile))
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Close();
                img_byte = ms.ToArray();
                imgfilelength = byte.Length;
            }
        } catch (Exception e) { MessageBox.Show(e.ToString()); }
    }
