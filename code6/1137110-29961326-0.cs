    private void OnMouseMove(object sender, MouseEventArgs mouseEventArgs)
    {
        var position = mouseEventArgs.GetPosition(this);
        MouseX = position.X;
        MouseY = position.Y;
    }
