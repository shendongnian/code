    class _exitGame
    {
        public event EventHandler ExitRequested = delegate {};
        Texture2D texture;
        Rectangle rectangle;
        public _exitGame(Texture2D newTexture, Rectangle newRectangle)
        {
            texture = newTexture;
            rectangle = newRectangle;
        }
        public void LoadContent()
        {
        }
        public void Update(GameTime gametime)
        {
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);
            var recWidth = rectangle.Width;
            var recHeight = rectangle.Height;
            if (rectangle.Contains(mousePosition))
            {
                rectangle.Width = 310;
                rectangle.Height = 60;
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    ExitRequested(this, EventArgs.Empty);
                }
            }
            else
            {
                rectangle.Width = 300; 
                rectangle.Height = 50;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle , Color.White);
        }
    }
