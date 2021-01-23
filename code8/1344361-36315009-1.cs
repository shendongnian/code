    public void Update(GameTime gameTime, MouseState mouse)
    {
        if (health > 0)
        {
            drawRectangle.X = (int) MathHelper.Clamp(mouse.X, 0, 
                      GraphicsDevice.Viewport.Width - drawRectangle.Width);
            drawRectangle.Y = (int) MathHelper.Clamp(mouse.Y, 0,
                      GraphicsDevice.Viewport.Height - drawRectangle.Height);
        }
        // ...
    }
