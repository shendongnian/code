    public interface ISpeakingAnimal {
        void Speak();
    } // end interface IAnimal
    public interface IHasPets {
    
        List<ISpeakingAnimal> Pets {get; set;}
        bool HasPets();
    } // end interface IHasPets
    public class Dog : ISpeakingAnimal {
    
        public void Speak() {
            Console.WriteLine("Woof");
        }
    } // end class Dog
    
    public class Cat : ISpeakingAnimal {
        
        public void Speak() {
            Console.WriteLine("Meow");
        }
    } // end class Cat
    public class Human : IHasPets {
        public Human() {
            Name = "The Doctor";
            Pets = new List<ISpeakingAnimal>();
        } // end constructor
        public string Name {get; set;}
        
        public List<ISpeakingAnimal> Pets {get; set;}
        public bool HasPets() {
          return Pets.Any();
        } // end method HasPets
        
    } // end class Human
    //Somewhere in your executing code
    Human person1 = new Human();
    ISpeakingAnimal dog = new Dog();
    ISpeakingAnimal cat = new Cat();
    person1.Pets.Add(dog);
    person1.Pets.Add(cat);
    
    for(int i = 0; i<person1.Pets.Count; i++) {
        person1.Pets[i].Speak();
    } // end for loop
