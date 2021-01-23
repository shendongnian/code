    public interface ISprite
    {
        void Draw();
    }
    
    public class BossMonster : ISprite
    {
        public override void Draw()
        {
            // Draw scary stuff
        }
    }
    public class Game
    {
        private List<ISprite> sprites = ...
        public void Render()
        {
            foreach(ISprite sprite in sprites)
            {
                sprite.Draw();
            }
        }
    }
