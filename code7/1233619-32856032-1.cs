    public class Monster
    {
        public string Name { get; private set; }
        public int HitPoints { get; set; }
        public string CharacterSheet
        {
            get
            {
                return Name + Environment.NewLine
                       + "HP: " + HitPoints;
            }
        }
        public Monster(string name, int hp)
        {
            Name = name;
            HitPoints = hp;
        }
    }
