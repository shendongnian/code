    SpriteTexture sprite;
    Vector2 position;
    ...
    protected override void Draw(GameTime gameTime)
    {
        graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
        spriteBatch.Begin();
        spriteBatch.Draw(sprite, position, Color.White);
        spriteBatch.End();
        base.Draw(gameTime);
    }
