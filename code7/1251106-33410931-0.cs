    public abstract class Animal
    {
        public abstract int NumberOfLegs { get; }
    }
    public class Tiger : Animal
    {
        private int numberOfLegs = 4;
        public override int NumberOfLegs
        {
            get
            {
                return numberOfLegs;
            }
        }
    }
