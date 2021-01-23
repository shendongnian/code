    public interface IAnimal { }
    public class Cat : IAnimal { }
    public class Dog : IAnimal { }
    public interface IAnimalShelter<T> where T : IAnimal
    {
        List<T> Animals { get; set; } 
    }
    public interface ICatShelter : IAnimalShelter<Cat> { }
    public interface IDogShelter : IAnimalShelter<Dog> { }
