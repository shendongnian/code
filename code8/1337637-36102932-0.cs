    public class Monster : PlayerType, IAttack
    {
        public override int Health()
        {
            return 100;
        }
        public void Attack(PlayerType)
        {
        }
    }
