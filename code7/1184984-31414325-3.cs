    public Bird : Animal, IFly, IHaveFeathers
    {
        public override void Move()
        {
            Fly();
        }
        public void Fly()
        {
            // your flying implementation
        }
        // rest of the implementation...
    }
