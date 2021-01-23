    public void CardMouseDown(object sender, MouseEventArgs e)
    {
        mouseOffset = new System.Drawing.Size(e.Location);
        clicked = true;
    }
    public void CardMouseUp(object sender, MouseEventArgs e)
    {
        clicked = false;
    }
    public void CardMouseMove(object sender, MouseEventArgs e)
    {
        if (clicked)
        {
            System.Drawing.Point newLocationOffset = e.Location - mouseOffset;
            ((Card)sender).Left += newLocationOffset.X;
            ((Card)sender).Top += newLocationOffset.Y;
            ((Card)sender).BringToFront();
        }
    }
