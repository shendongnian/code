    //In main game class
    public void Update(GameTime gameTime)
    {
        foreach (Entity e in Entities)
            e.Update(gameTime);
    }
    public override void Draw(GameTime gameTime)
    {
        foreach (Entity e in Entities)
            e.Draw(spriteBatch);
    }
