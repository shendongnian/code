    private void cb_Save_Click(object sender, EventArgs e)
    {
        SaveFileDialog sfd = new SaveFileDialog();
        // .. add more formats if you want here!
        sfd.Filter = "Jpg|*.jpg|Jpeg|*.jpeg|PNG|*.png";
        ImageFormat format = ImageFormat.Jpeg;
        if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            if (sfd.FileName.ToLower().EndsWith(".png")) format = ImageFormat.Png;
            // ..and here!
        }
        ((Bitmap)pictureBox1.Image).SetResolution(ImgDpi.X, ImgDpi.Y);
        pictureBox1.Image.Save(sfd.FileName, format); 
    }
