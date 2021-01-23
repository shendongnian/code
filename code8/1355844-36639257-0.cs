    class Program
    {
        static void Main(string[] args)
        {
            int convertingChartToInt = 'A'; // Valid - Covert Chart to int and store it in this variable.
            int covertDecimalToString = 5.0m; // Invalid - Convert Decimal to String and Store it in this variable.
            ICollection<String> covertListToICollection = new List<string>(); // Valid List<T> Implements ICollection<T>
    
            List<Animal> animals = new List<Animal>();
            List<Dog> myDogs = new List<Dog>();
    
            Animal myOstrichAsAnimal = new Ostrich();
            Animal myDogAsAnimal = new Dog();
            Dog myDogAsDog = new Dog();
    
            myOstrichAsAnimal.BuryHeadInGround(); // Will not Compile
            (myOstrichAsAnimal as Ostrich).BuryHeadInGround(); // Will Compile
    
            myDogAsAnimal.Bark(); // Will Not Compile
            myDogAsDog.Bark(); // Will Compile
    
            AdapotAnimal(myOstrichAsAnimal); // Will Compile
    
            animals.Add(myOstrichAsAnimal); // Will Compile
            animals.Add(myDogAsAnimal); // Will Compile
            animals.Add(myDogAsDog); // Will Compile
    
            FeedAnimals(animals); // Will Compile
        }
    
        private static void AdapotAnimal(Animal animal)
        {
    
        }
    
        private static void FeedAnimals(List<Animal> animals)
        {
    
        }
    }
    
    public class Animal
    {
        public int NumberOfFeet { set; get; }
    }
    
    public class Ostrich : Animal
    {
        public void BuryHeadInGround()
        {
    
        }
    }
    
    public class Dog : Animal
    {
        public void Bark()
        {
    
        }
    }
