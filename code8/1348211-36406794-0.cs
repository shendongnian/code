    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        isDragging = true;
        move = e.Location;
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        PictureBox pictureBox = sender as PictureBox;
        if(isDragging == true)
        {
            pictureBox .Left += e.X - move.X;
            pictureBox .Top += e.Y - move.Y;
            pictureBox .BringToFront();
        }
    }
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        isDragging = false;
    }
