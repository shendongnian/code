    abstract class Animal
    {
        protected int numberOfLegs = 4; // default number of legs
        public int NumberOfLegs { get { return numberOfLegs; } }
    
        public Animal(int legs)
        {
            numberOfLegs = legs; // initialize number of legs
        }
    }
