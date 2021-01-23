    public void Update(GameWindow window)
    {
        var mouseState = Mouse.GetState();
        var mousePoint = new Point(mouseState.X, mouseState.Y);
        var rectangle = new Rectangle(mousePoint.X, mousePoint.Y, this.texture.Width, this.texture.Height);
        if (rectangle.Contains(mousePoint))
        {
            isHovered = true;
            isClicked = mouseState.LeftButton == ButtonState.Pressed;
        }
        else
        {
            isHovered = false;
            isClicked = false;
        }
    }
