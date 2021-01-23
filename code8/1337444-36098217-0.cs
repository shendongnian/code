    class Sprite
    {
        Texture2D mSpriteTexture;
        public Vector2 Position;
        Color mSpriteColor;
        public Rectangle Size;
        public string AssetName;
        private float mScale = 1.0f;
        public float Scale 
        {
            get { return mScale; }
            set
            {
                mScale = value;
                //Recalculate the Size of the Sprite with the new scale
                Size = new Rectangle(0, 0, (int)(mSpriteTexture.Width * Scale), (int)(mSpriteTexture.Height * Scale));
            }
        }
        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            mSpriteTexture = theContentManager.Load<Texture2D>(theAssetName);
            AssetName = theAssetName;
            Size = new Rectangle(0, 0, (int)(mSpriteTexture.Width * Scale), (int)(mSpriteTexture.Height * Scale));
        }
        public  void Update(GameTime gameTime)
        {
           
        }
        public void Draw(SpriteBatch theSpriteBatch)
        {
             theSpriteBatch.Draw(mSpriteTexture, Position,
                new Rectangle(0, 0, mSpriteTexture.Width, mSpriteTexture.Height),
                 Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
            //theSpriteBatch.Draw(mSpriteTexture, Position);
        }
       }
    }
