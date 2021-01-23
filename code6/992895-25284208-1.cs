        interface IDrawable {
           Draw(WeaponDrawer)
        }
    
        class DrawableWeapon : Weapon, IDrawable {
          Draw(WeaponDrawer wd){
            wd.Draw(this);
         }
        }
        class WeaponDrawer {
           Draw(Weapon weapon){
              //drawing logic here
           }
        }
