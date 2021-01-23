    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        mouseDown = true;
    }
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
        mouseDown = false;
    }
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (mouseDown)
        {
            mouseX = MousePosition.X - 20;
            mouseY = MousePosition.Y - 40;
            this.SetDesktopLocation(mouseX, mouseY);
        }
    }
