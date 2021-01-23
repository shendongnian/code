    private void pictureBox_MouseClick(object sender, MouseEventArgs e)
    {
        var pic = (sender as PictureBox).Name;//pic is the Name of the PictureBox that is clicked
        switch (e.Button)
        {
            case MouseButtons.Right:
            {
                MessageBox.Show(pic);//Just for example
                DesktopIconRightclick.Show(this, new Point(e.X, e.Y));
            }
            break;
        }
    }
