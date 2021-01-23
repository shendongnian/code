    abstract class Animal
    {
        public abstract Cage GetCage();
    }
    public class Fish : Animal
    {
        public override Aquarium GetCage() { ... }
    }
