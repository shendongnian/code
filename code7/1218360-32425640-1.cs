    public abstract class Entity
    {
        public abstract void Draw(); // no implementation here
        public virtual void UpdateEntity(GameTime gameTime)
        {
            // default update
        }
    }
