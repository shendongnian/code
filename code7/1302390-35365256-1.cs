    protected override void Draw(GameTime gameTime)
    {
        spriteBatch.Begin();
        // Draw things before ball ...
        if (ballSpeed > 10f)
        {
            spriteBatch.Draw(fireTexture, ballPosition, null, Color.White);
        }
        else
        {
            spriteBatch.Draw(texture, ballPosition, null, Color.White);
        }
        // Draw the other things...
        spriteBatch.End();
    }
