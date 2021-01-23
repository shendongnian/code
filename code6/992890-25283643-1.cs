        public class Weapon
        {
           public void Shot()
           { 
              // Some code...
           }
        }
        public class MachineGun : Weapon
        {
           public void Shot()
           { 
              // Extend base code...
           }
        }
 
        public class DrawableWeapon : Weapon
        {
           Weapon mWeapon;
        
           public void Shot()
           { 
              mWeapon.Shot();
           }
        
            // Adding draw calls and properties
        }
