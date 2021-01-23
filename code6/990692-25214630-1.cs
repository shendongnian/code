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
    public class NPC : ISprite
    {
        public override void Draw()
        {
            // Draw stuff
        }
    }
    public class Game
    {
        private ISprite currentSprite = ...
        private List<ISprite> otherSprites = ...
        public void Render()
        {
            currentSprite.Draw();
            foreach (ISprite sprite in otherSprites)
            {
                sprite.Draw();
            }
        }
    }
