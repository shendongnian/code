        public class Weapon
        {
           public virtual void Shot()
           { 
              // Some code...
           }
        }
        public class MachineGun : Weapon
        {
           public override void Shot()
           { 
              // Extend base code...
           }
        }
 
        public class DrawableWeapon : Weapon
        {
           Weapon mWeapon;
        
           public override void Shot()
           { 
              mWeapon.Shot();
           }
        
            // Adding draw calls and properties
        }
