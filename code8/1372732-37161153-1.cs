    public class AnimalManager
    {
        public void WatchAnimal<TAggressiveAnimal, TAnimal>
            (TAggressiveAnimal aggressive, TAnimal enemy)
            where TAggressiveAnimal : IAnimalAgressive<TAnimal>
        {
            Console.WriteLine(aggressive.Bark(enemy));
        }
    }
