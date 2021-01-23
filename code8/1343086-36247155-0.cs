    public static class Data 
    {
        public Weapon[] GetUnlockedWeapons(this IEnumerable<Weapon> weapons)
        {
            return weapons.Where( a => a.unlocked ).ToArray();
        }
    
        public static GetWeaponsType(this IEnumerable<Weapon> weapons, string type) 
        {
            return weapons.Where( a => a.type == type ).ToArray();
        }
    }
