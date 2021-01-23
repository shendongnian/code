    public class PowerUps : DrawableGameComponent
    {
        //Variables
        public PowerUps(Texture2D newText, Vector2 newPos, Game1 game) : base(game)
        {
            position = newPos;
            texture = newText;
        }
