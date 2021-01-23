    /// <summary>
    /// This is an enum, that defines the different species of animals
    /// </summary>
    enum Species {Mammal, Fish, Insect, Bird}
    /// <summary>
    /// This is the base class for all animals
    /// The class is abstract, so that we cant instantiated (Animal a = new Animal() is no longer possible)
    /// It wouldn't make any sense to instantiate an animal (what color does and animal have, how many legs etc....) thats why its abstract
    /// </summary>
    abstract class Animal
    {
        /// <summary>
        /// All animals has teeth, so we add this field to the animal
        /// </summary>
        private int teeth;
        /// <summary>
        /// All animals have legs, so we add this field in the animal as well
        /// </summary>
        private int legs;
        /// <summary>
        /// I'm not 100% sure about how the species should work
        /// I just implemented and enum for 3 species
        /// This can be adapted to suit your needs
        /// </summary>
        private Species species;
        /// <summary>
        /// This is the constructor of the animal. this constructor takes in 
        /// all the base values of the animal
        /// </summary>
        /// <param name="species">The current animals species</param>
        /// <param name="legs">The current animal's amount of legs</param>
        /// <param name="teeth">The current animal's amount of theeth</param>
        public Animal(Species species, int legs, int teeth)
        {
            //Sets the number of teeth on the current animal
            this.teeth = teeth;
            //Sets the number of legs on the current animal
            this.legs = legs;
            //Sets the species of the current animal
            this.species = species;
        }
    }
