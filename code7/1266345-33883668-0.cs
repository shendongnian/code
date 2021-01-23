    public void DrawLevelBoxes(SpriteBatch spriteBatch)
    {
        LevelBoxX = 20;
        for (int i = 0; i < 10; i++)
        {
            spriteBatch.Draw(levelboxbg.texture, new Vector2(LevelBoxX + 20 ,0), levelboxbg.color);
            LevelBoxX += 20;
        }
    }
