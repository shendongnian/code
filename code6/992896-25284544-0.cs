    public class DrawableWeapon<T> : Weapon where T : Weapon
    {
         T _weapon;
  
         public void Shot()
         {
            _weapon.Shot();
         }
    }
