    private void pictureBox_MouseDown(object sender, MouseEventArgs e)
    {
        isDragging = true;
        move = e.Location;
    }
    private void pictureBox_MouseMove(object sender, MouseEventArgs e)
    {
        if(isDragging == true)
        {
            // Luckily the sender parameter will tell us which PictureBox we are dealing with
            PictureBox pb = (PictureBox)sender;
            pb.Left += e.X - move.X;
            pb.Top += e.Y - move.Y;
            pb.BringToFront();
        }
    }
    private void pictureBox_MouseUp(object sender, MouseEventArgs e)
    {
        isDragging = false;
    }
