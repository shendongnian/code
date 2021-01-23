    public class Game
    {
        private int score;
    
        void Draw(...)
        {
           spriteBatch.DrawString(font, "Score: " + score.ToString(), scorePos, Color.White);
        }
    }
