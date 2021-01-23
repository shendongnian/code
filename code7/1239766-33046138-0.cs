    int prevMouseX;
    int prevMouseY;
    private void mouseDown(object sender, MouseEventArgs e)
    {
        prevMouseX = e.X;
        prevMouseY = e.Y;
    }
    private void mouseUp(object sender, MouseEventArgs e)
    {
        if (prevMouseX == e.X && prevMouseY == e.Y)
            mouseClick(sender, e);
    }
    private void mouseClick(object sender, MouseEventArgs e)
    {
        //Do Stuff
    }
