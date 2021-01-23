    abstract class Spaceship
    {
        abstract public int LaserHit();
    }
    class CombatShip : Spaceship
    {
        public override int LaserHit()
        {
           int L = 10;
           return L;
        }
    }
