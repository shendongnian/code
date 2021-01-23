    private void picMouseMove(object sender, MouseEventArgs e)
    {
        if (drag)
        {
            // Get new position of picture
            pic[i].Top += e.Y - y;    //this i here is wrong
            pic[i].Left += e.X - x;
            pic[i].BringToFront();
        }
    }
