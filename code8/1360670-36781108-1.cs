    class Animal
    {
        public virtual void Move() { }
    }
    class Mammal : Animal
    {
        public sealed override void Move() { }
    }
    class Rabbit : Mammal
    {
        
        public override void Move() { } // error
    }
