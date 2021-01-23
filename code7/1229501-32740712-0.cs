    protected void btnRotateImg_Click(object sender, EventArgs e)
    {
        Bitmap bit1 = new Bitmap(Server.MapPath("mydir/img.jpg"));
        Graphics gbit1 = Graphics.FromImage(bit1);
        bit1 = RotateImg(bit1, 100f,   Color.FromName(colors.SelectedItem.ToString())); // Modification here
        Rectangle r = new Rectangle(0,0,(int)bit1.Width, (int)bit1.Height);
        bit1.Save(Server.MapPath("mydir/imgnew.jpg"));
    }
