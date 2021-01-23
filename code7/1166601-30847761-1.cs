    public interface IAttackWeapon : IFeature
    {
        int Damage { get; set; }
    }
    public interface IDefenceWeapon : IFeature
    {
        int Block { get; set; }
    }
