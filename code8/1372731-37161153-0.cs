    public interface IAnimalAgressive<in TAnimal>
    {
        string Bark(TAnimal animal);
    }
    public abstract class AnimalAggressiveBase<TEnemy> : IAnimalAgressive<TEnemy>
    {
        public abstract string BarkAtEnemy(TEnemy enemy);
        public string Bark(TEnemy enemy)
        {
            return BarkAtEnemy(enemy);
        }
    }
