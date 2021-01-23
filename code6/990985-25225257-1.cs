    abstract class GameObject
    {
        ...
        public abstract void Update();
    }
    
    class Ammo : GameObject
    {
        public override void Update()
        {
            // Stuff to update Ammo
        }
    }
