    static class Data {
    
        // ...
    
        static public Weapon[] weapons = new Weapon[] {
            // ...
        }
    
        public static IEnumerable<Weapon> GetUnlockedWeapons(this IEnumerable<Weapon> weapons) {
            return weapons.Where( a => a.unlocked );
        }
    
        public static IEnumerable<Weapon> GetWeaponsType(this IEnumerable<Weapon> weapons, string type) {
            return weapons.Where( a => a.type == type );
        }
    
    // ...
    }
