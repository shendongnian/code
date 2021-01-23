    class Unit
    {
        public virtual void Attack()
        {
            Console.WriteLine("Unit attacks!");
        }
    }
    class Wolf : Unit
    {
        public override void Attack()
        {
            Console.WriteLine("Wolf attacks!");
        }
    }
    class Spider : Unit
    {
        public override void Attack()
        {
            Console.WriteLine("Spider attacks!");
        }
    }
