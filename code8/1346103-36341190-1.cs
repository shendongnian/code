    public virtual void Draw(SpriteBatch spriteBatch)//Draws object/sprites
    {
        if (!isAlive)
            return;
        spriteBatch.Draw(Texture, position, null, Color.White, MathHelper.ToRadians(Rotation), center, scale,SpriteEffects.None, 0);
    }
