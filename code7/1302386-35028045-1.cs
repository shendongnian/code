     public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            ...
            if (ballSpeed > 10f)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(fireball, ballPosition, null, Color.White);
                spriteBatch.End();
            }
            ...
        }   
