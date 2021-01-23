    public abstract class Weapon {
        public int cost {get; set;}
    }
    public class Sword : Weapon {
        public int damage {get; set;}
    }
    public class Shield : Weapon {
        public int defense {get; set;}
    }
