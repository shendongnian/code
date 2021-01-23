    public class Weapon : IAttackWeapon
    {
        public Damage { get; set }
    }
    public class Shield : IDefenceWeapon
    {
        public int Block { get; set; }
    }
