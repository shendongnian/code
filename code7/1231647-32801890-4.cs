    [Export(typeof(IAnimalCatcher<IAnimal>))]
    public class DogCatcher: IAnimalCatcher<IAnimal>
    {
        public string WhatICatch()
        {
            return "Dogs";
        }
    
        public IAnimal AnimalCaught { get; set; }
    }
