    public class Bullet
    {
    public delegate void OnHit(bool something);
    public OnHit onHitMethod;
    public int Damage;
    public Bullet(int Damage, OnHit OnHit)
    {
        this.Damage = Damage;
        this.onHitMethod = OnHit;
    }
    }
