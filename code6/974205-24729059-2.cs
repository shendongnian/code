    public void Intersect(Rectangle rectangle, SpriteBatch spriteBatch)
    {
        foreach (Rectangle kiwiRect in kiwiRectangle.Except(collectedKiwis))
        {
            if (kiwiRect.Intersects(playerRect))
            {
                collectedKiwis.Add(kiwiRect);
            }
            else
            {
                spriteBatch.Draw(kiwiTexture, kiwiRect, Color.White);
            }
        }
    }
