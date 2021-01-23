    class Coal
    {
        public Texture2D coalTexture;
        public Vector2 Position;
        private float scale = 4f;
    
        public int Width
        {
            get { return coalTexture.Width * scale; }
        }
    
        public int Height
        {
            get { return coalTexture.Height * scale; }
        }
    
        [...]
    
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(coalTexture, Position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }
    }
