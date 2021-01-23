Also, you could shorten the Draw function, to look like this (explanation in Suggestion No2):
    public void Draw(SpriteBatch spritebatch)
    {
        for (int i = 0; i <= col-1; i++)
        {
            for (int j = 0; j <= row-1; j++)
            {
                Color newColor;
                switch(gridCell[i, j])
                {
                    case 0: newColor = Color.CornflowerBlue; break;
                    case 1: newColor = Color.Yellow; break;
                    case 2: newColor = Color.Red; break;
                    case 3: newColor = Color.Purple; break;
                    case 4: newColor = Color.Blue; break;
                    case 5: newColor = Color.Black; break;
                    default: newColor = Color.White; break;
                }
                spritebatch.FillRectangle(i * 32, j * 32, 31, 31, newColor, 0f);
                spritebatch.DrawRectangle(new Vector2(i * 32, j * 32), new Vector2(32, 32), Color.Black, 1f);
                
            }
        }
    }
