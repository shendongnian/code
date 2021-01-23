    class Enemy : Sprite
    {
        const string ENEMY_ASSETNAME = "gear";
        Random Rand = new Random();
        //int startPos_X;
        //int startPos_Y;
        
        public void LoadContent(ContentManager theContentManager)
        {
            Position = new Vector2(Position.X ,Position.Y);
            base.LoadContent(theContentManager, ENEMY_ASSETNAME);
        }
        public void Update(GameTime gameTime)
        {
            MouseState cState = Mouse.GetState();
            if (Position.X > cState.X)
            {
                Position.X += 1;
            }
            if (Position.X < cState.X)
            {
                Position.X -= 1;
            }
            if (Position.Y < cState.Y)
            {
                Position.Y -= 1;
            }
            if (Position.Y > cState.Y)
            {
                Position.Y += 1;
            }
            base.Update(gameTime);
        }        
      }
    }
