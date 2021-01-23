    public void Intersect(Rectangle rectangle, SpriteBatch spriteBatch)
    {
        foreach (Rectangle kiwiRect in kiwiRectangle)
        {
            if (!isCollected)
            {
                if (kiwiRect.Intersects(playerRect))
                {
                    isCollected = true;
                }
            }
            if (!isCollected)
            {
                spriteBatch.Draw(kiwiTexture, kiwiRect, Color.White);
            }
        }
    }
