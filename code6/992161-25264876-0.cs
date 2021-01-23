    protected override void Draw (GameTime gameTime)
    {
        graphics.GraphicsDevice.Clear (Color.Black);
        newVector = nextVector (oldVector);
        
        GraphicsDevice.SetRenderTarget(renderTarget);
        spriteBatch.Begin ();
        DrawEvenlySpacedSprites (dot, oldVector, newVector, 0.9f);
        spriteBatch.End ();
        GraphicsDevice.SetRenderTarget(null);
        spriteBatch.Begin();
        spriteBatch.Draw(renderTarget, new Vector2(), Color.White);
        spriteBatch.Draw (tool, toolPos, Color.White);
        spriteBatch.End()
        oldVector = new Vector2 (newVector.X, newVector.Y);
        base.Draw (gameTime);
    }
