    public void draw(SpriteBatch spriteBatch, Vector2 offset = default(Vector2), float rotation = 0f)
    {
    spriteBatch.Begin(); //Starts the drawing loop
    spriteBatch.Draw(texture, offset + pos, null, Color.White, rot+rotation,   sprite.origin, 1f, SpriteEffects.None, z);
    foreach (var child in children)
    {
        child.draw(spriteBatch, offset + pos, rotation + rot);
    }
    spriteBatch.End();  // This is for ending the drawing loop.
    }
