    private void Window_MouseMove(object sender, MouseEventArgs e)
    {
        Point position = Mouse.GetPosition(this);
        Cursorposition.Text = "X:" + position.X + "Y:" + position.Y;
    }
