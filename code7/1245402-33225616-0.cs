    class Program
    {
        static void Main(string[] args)
        {
            var defaultMonster = new Monster();
            var archerMonster = new Monster("crossbow");
            var knightMonster = new Monster("broadsword", "plate mail");
            var wizardMonster = new Monster(armor: "wizard robe", magicItem: "wand");
            Console.WriteLine(defaultMonster);
            Console.WriteLine(archerMonster);
            Console.WriteLine(knightMonster);
            Console.WriteLine(wizardMonster);
        }
    }
    class Monster
    {
        private readonly string _weapon;
        private readonly string _armor;
        private readonly string _magicItem;
        public Monster(string weapon = "scimitar", string armor = "leather", string magicItem = "nothing")
        {
            _weapon = weapon;
            _armor = armor;
            _magicItem = magicItem;
        }
        public override string ToString()
        {
            return string.Format("Monster armed with {0}, wearing {1}, carrying {2}", _weapon, _armor, _magicItem);
        }
    }
