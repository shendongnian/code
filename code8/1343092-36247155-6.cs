    public class Data 
    {
        public Data(Weapon[] weapons)
        {
            this.Weapons = weapons;
        }
        public Weapon[] weapons { get; private set; }
        public Data GetUnlockedWeapons()
        {
            return new Data(this.Weapons.Where( a => a.unlocked ).ToArray());
        }
    
        public Data GetWeaponsType(this IEnumerable<Weapon> weapons, string type) 
        {
            return new Data(this.Weapons.Where( a => a.type == type ).ToArray());
        }
    }
