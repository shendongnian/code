    public class Game1 : Microsoft.Xna.Framework.Game
    {
        Quiz quiz;
        protected override void LoadContent()
        {
            quiz.LoadContent(Content);
        }
        protected override void Update(GameTime gameTime)
        {
            quiz.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            quiz.Draw(spriteBatch, gameTime);
        }
    }
