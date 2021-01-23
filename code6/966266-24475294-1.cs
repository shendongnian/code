    private void picMouseMove(object sender, MouseEventArgs e)
    {
        if (drag)
        {
            PictureBox pb = (PictureBox ) sender;
            // Get new position of picture
            pb.Top += e.Y - y;    
            pb.Left += e.X - x;
            pb.BringToFront();
        }
    }
