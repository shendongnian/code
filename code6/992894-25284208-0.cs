        interface IDrawable {
           Draw(WeaponDrawer)
        }
    
        class DrawableWeapon : Weapon, IDrawable {
          Draw(WeaponDrawer wd){
            wd.Draw();
         }
        }
        class WeaponDrawer {
           Draw(){
              //drawing logic here
           }
        }
