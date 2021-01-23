    class Program
    {
        static void Main(string[] args)
        {
            Animal dog = new Dog();
            MakeSoundAbstract(dog);
            Animal an = new Animal();
            MakeSoundAbstract(an);
       
            Console.ReadLine();
        }
    
        static void MakeSoundAbstract(Animal animal)
        {
            animal.MakeSound();
        }
    }
