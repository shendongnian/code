    [Export(typeof(IAnimalCatcher<IAnimal>))]
    public class DogCatcher: IAnimalCatcher<Dog>
    {
        public string WhatICatch()
        {
            return "Dogs";
        }
    
        public Dog AnimalCaught { get; private set; }
    }
