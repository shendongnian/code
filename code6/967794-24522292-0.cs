    class Dog : Animal {
        public Dog () {
            base.Animal("Doggy", AnimalType.Dog);
        }
        public override void PrintAnimal () {
            Console.WriteLine("Bark");
        }
    }
