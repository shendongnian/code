    class Wall
    {
        public virtual void CheckCollision(some arguments)
        {
            // default collision check code
        }
    }
    
    class Door : Wall
    {
        public override void CheckCollision(some arguments)
        {
            // overriden collision check code
        }
    }
