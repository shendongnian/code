    private void pictureBox_MouseClick(object sender, MouseEventArgs e)
    {
        var pic = (sender as PictureBox).Name;
        switch (e.Button)
        {
            case MouseButtons.Right:
            {
                MessageBox.Show(pic);
                //DesktopIconRightclick.Show(this, new Point(e.X, e.Y));
            }
            break;
        }
    }
