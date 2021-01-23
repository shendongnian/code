    public void Draw(SpriteBatch spriteBatch)
    {
        for (int y = 0; y < tileMap.GetLength(0); y++)
        {
            for (int x = 0; x < tileMap.GetLength(1); x++)
            {
              if(tileMap[y,x] != 4)
                {
                spriteBatch.Draw(
                    tiles[tileMap[y, x]],
                    new Vector2(x * tileWidth, y * tileHeight),
                    Color.White);
                }
            }
        }
    }
