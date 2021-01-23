    public class Battle
    {
        public IFighter Attacker = Monster;
        public IFighter Target = Character;
        public void Attack(bool characterAttacking)
        {
            if (characterAttacking)
            {
                Attacker = Character;
                Target = Monster;
            }
        }
    }
