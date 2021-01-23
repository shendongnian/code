     for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 6; y++)
            {
                try
                {
                    gameGrid[x, y].pipe.Draw(spriteBatch);
                }
                catch (NullReferenceException)
                {
                    continue;
                }
            }
        }
