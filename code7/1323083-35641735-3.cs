    public abstract class Weapon : MonoBehaviour
    {
      public abstract string Name { get; }
    }
    public abstract class RangedWeapon : Weapon
    {
      public abstract int RateOfFire { get; }
    }
    public class Rifle : RangedWeapon
    {
      public override string Name { get { return "rifle"; } }
      public override int RateOfFire { get { return 5; } }
    }
    
    public class Sword : Weapon
    {
      public override string Name { get { return "sword"; } }
    }
