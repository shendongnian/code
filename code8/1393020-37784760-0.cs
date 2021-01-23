    class Animal
    {
    }
    class Dog : Animal
    {
    }
    class AnimalManipulator<TAnimal> where TAnimal : Animal
    {
        readonly Dictionary<string, TAnimal> animals = new Dictionary<string, TAnimal>();
        public void Test()
        {
            // Here you are forced to cast to the dictionary value type, because
            // what you are doing is NOT SAFE:
            animals.Add("Animal", (TAnimal)new Animal());
        }
    }
