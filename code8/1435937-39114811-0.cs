    public class Bullet
    {
        public int Damage;
        System.Action savedFunc;
    
        public Bullet(int Damage, System.Action OnHit)
        {
            if (OnHit == null)
            {
                throw new ArgumentNullException("OnHit");
            }
    
            this.Damage = Damage;
            savedFunc = OnHit;
        }
    
        //Somewhere in your Bullet script when bullet damage == Damage
        void yourLogicalCode()
        {
            int someBulletDamage = 30;
            if (someBulletDamage == Damage)
            {
                //Call the function
                savedFunc.Invoke();
            }
        }
    }
