        T GetAnimal();
    }
    
    public class Dog : IAnimal<Dog>
    {
        public Dog GetAnimal() { return new Dog(); }
    }
