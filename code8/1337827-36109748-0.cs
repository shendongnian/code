    using System.Collections.Generic;
    class PaintingAnimals {
      class Animal {}
      class Cat : Animal {}
      class Dog : Animal {}
      static void Paint(Cat cat) { System.Console.WriteLine("Cat"); }
      static void Paint(Dog dog) { System.Console.WriteLine("Dog"); }
      static void Paint(Animal animal) { System.Console.WriteLine("Animal"); }
      public static void Main() {
        var animals = new List<Animal> {new Cat(), new Dog()};
        foreach (dynamic animal in animals) { // Uses "dynamic", not "var"
          Paint(animal); // Print's "Cat" and "Dog" respectively, not "Animal"
        }
      }
    }
