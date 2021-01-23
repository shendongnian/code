    class Character
    {
        public int HP;
        public int atkP = 0;
        public bool Dash = false;
        public double Target; //Equal to chosen enemy Loc
        public bool isAttacking = false;
        public int LocX = 1;
        public int LocY = 1;
        public Character()
        {
        }
        public virtual void HandleInput()
        {
        }
        //public override void Attack()
        //{
        //    if (isAttacking == true)
        //    {
        //        HP -= atkP;                
        //    }
        //}
    }
