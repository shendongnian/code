        public class DogTrait : PetTrait
        {
            public IEnumerable<Dog> DogsWithTrait 
            { 
                get { return PetsWithTrait.OfType<Dog>(); } 
            }
        }
