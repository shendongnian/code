    abstract public class Enemy
    {
        public string name { get; set; }
        public int baseHealth { get; set; }
        public int baseAttackDamage { get; set; }
        public int baseMagicDamage { get; set; }
        public int level { get; set; }
        public int baseMoneyDropped { get; set; }
        public string damageType { get; set; }
        public Player player { get; set;}
        
        public Enemy()
        {
            player = new Player();
        }
        public int GenerateEnemyLevel()
        {
            Random genEnemyLevelModifier = new Random();
            int getEnemyLevel = genEnemyLevelModifier.Next(-3, 3) + player.level;
            return(getEnemyLevel);
        }
    }
