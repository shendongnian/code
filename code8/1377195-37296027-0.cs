    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && pictureBox1.Tag == null)
            pictureBox1.DoDragDrop(pictureBox1.Image, DragDropEffects.All);
    }
    private void pictureBox2_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(PictureBox)))
            e.Effect = DragDropEffects.Copy;
        else
            e.Effect = DragDropEffects.None;
    }
    private void pictureBox2_DragDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(PictureBox)))
        {
            var picturebox = ((PictureBox)e.Data.GetData(typeof(PictureBox)));
            picturebox.Tag = true;
            this.pictureBox2.Image = picturebox.Image;
        }
    }
