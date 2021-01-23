    /// <summary>
    /// This is a duck class, it inherits from the Animal class
    /// Inheritance is done in C# by using Class A : Class B
    /// The point of inheritance is to pass on members and functionality from a superclass to a sub class
    /// In this case we give the duck legs, teeth and a species
    /// </summary>
    class Duck : Animal
    {
        private int wingSpan;
        /// <summary>
        /// This is the constructor of the Duck subclass
        /// It takes in all the parameters that the super class needs +wingSpan
        /// It passes on the superclass parameters to the Animal class by calling the super class constructer with the
        /// Keyword base()
        /// </summary>
        /// <param name="wingSpan">The duck's wingspan</param>
        /// <param name="species">The species of the duck</param>
        /// <param name="legs">The amount of legs of the duck</param>
        /// <param name="teeth">The duck's amount of teeth</param>
        public Duck(int wingSpan, Species species, int legs, int teeth) : base(species,legs,teeth)
        {
            //sets the ducks number of wings
            this.wingSpan = wingSpan;
        }
    }
