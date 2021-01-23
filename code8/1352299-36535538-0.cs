    public void Draw()
    {
        spriteBatch.Begin();
        for (int i = 0; i < 770; i += 31)
        {
            position = new Vector2(i, 330);
            if (i == 744)
            {
                i = i + 26;
                position = new Vector2(i, 330);
            }
            spriteBatch.Draw(gameTile, position, Color.White);
        }
        spriteBatch.End();
    }
