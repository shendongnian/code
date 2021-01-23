        public static class WeaponFilters
        {
             public static Weapon[] GetUnlocked(this Weapon[] w)
            {
                 return w.Where(x=> x.unlocked).ToArray();
            }
             public static Weapon[] Type(this Weapon[] w, string type)
            {
                 return w.Where(x=> x.type == type).ToArray();
            }
       //some more filters...
        }
