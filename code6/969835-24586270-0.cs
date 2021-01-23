    abstract class Animal
    {
        private readonly int numberOfLegs; 
        protected Animal(int nrLegs = 4)
        {
           numberOfLegs = nrLegs;
        }
        public int returnNumberOfLegs()
        {
          return numberOfLegs;
        }
    }
    
    class Snake : Animal
    {
       public Snake() : base(0)
       {
       }
    }
