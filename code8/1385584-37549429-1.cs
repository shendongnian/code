    using System;
    namespace Demo
    {
        class Animal
        {
            public virtual void MakeNoise() {}
        }
        class Dog: Animal
        {
            public override void MakeNoise()
            {
                Bark();
            }
            public void Bark() {}
        }
        class Cat : Animal
        {
            public override void MakeNoise()
            {
                Meow();
            }
            public void Meow() {}
        }
        class Program
        {
            static void handleAnimal(Animal animal) // I can handle cats AND dogs.
            {
                animal.MakeNoise();
            }
            static void handleCat(Cat cat) // I only handle cats.
            {
                cat.Meow();
            }
            static Cat createCat() // I only create cats.
            {
                return new Cat();
            }
            static Dog createDog() // I only create dogs.
            {
                return new Dog();
            }
            static Animal createAnimal() // I only create animals.
            {
                return new Animal();
            }
            public static void Main()
            {
                // Action<T> is contravariant.
                // Since the parameter of handleAnimal() is of type Animal,
                // it can handle both cats and dogs. Therefore Action<Cat> 
                // and Action<Dog> can both be assigned from it.
                Action<Cat> catAction = handleAnimal;
                Action<Dog> dogAction = handleAnimal;
                catAction(new Cat()); // Cat passed to handleAnimal() - OK.
                dogAction(new Dog()); // Dog passed to handleAnimal() - OK.
                // Imagine that Action<T> was covariant.
                // Then you would be able to do this:
                Action<Animal> animalAction = handleCat; // This line won't compile, because:
                animalAction(new Animal());              // Animal passed to handleCat() - NOT OK!
                // Func<T> has a covariant return type.
                // Since the type returned from Func<Animal> is of type Animal, 
                // any type derived from Animal will do.
                // Therefore it can be assigned from either createCat() or createDog().
                Func<Animal> catFunc    = createCat;
                Func<Animal> dogFunc    = createDog;
                Func<Animal> animalFunc = createAnimal;
                Animal animal1 = catFunc();    // Cat returned and assigned to Animal - OK.
                Animal animal2 = dogFunc();    // Dog returned and assigned to Animal - OK.
                Animal animal3 = animalFunc(); // Animal returned and assigned to Animal - OK.
                // Imagine that Func<T> was contravariant.
                // Then you would be able to do this:
                Func<Cat> catMaker = createAnimal; // This line won't compile because:
                Cat cat = catMaker();              // Animal would be assigned to Cat - NOT OK!
            }
        }
    }
