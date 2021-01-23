    class Wolf : IUnit
    {
        public int Health { get; set; }
        public void Attack()
        {
            Console.WriteLine("Wolf attacks!");
        }
    }
    class Spider : IUnit
    {
        public int Health { get; set; }
        public void Attack()
        {
            Console.WriteLine("Spider attacks!");
        }
    }
