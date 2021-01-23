    Image img;
    if(dt.Rows[0] != System.DBNull.Value)
    {
        byte[] bytimg = (byte[])dt.Rows[0]["Picture"];
        //convert byte of imagedate to Image format
        using (MemoryStream ms = new MemoryStream(bytimg, 0, bytimg.Length))
        {
            ms.Write(bytimg, 0, bytimg.Length);
            img = Image.FromStream(ms, true);
            if (img != null)
            {
                pictureBox1.Image = img;
            }
        }
    }
