    public Button(Texture2D newText, GraphicsDevice graphics)
        {
            texture = newText; 
            size = new Vector2(graphics.Viewport.Width / 20, graphics.Viewport.Height / 10);
            rectangle = new Rectangle(0, 0, size.X, size.Y);
        }
