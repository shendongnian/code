    abstract class Animal
    {
        public abstract int NumberOfLegs { get; }
    }
    class Snake : Animal
    {
        public override int NumberOfLegs { get { return 0; } }
    }
