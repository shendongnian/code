    public class Hero : PlayerType, IAttack
    {
        public override int Health()
        {
           return 500; // He is a hero afterall ;)
        }
        public void Attack(PlayerType)
        {
        }
    }
