    public interface AnimalAgressiveBase<TAnimal>
    {
        string Bark(TAnimal animal);
    }
    public abstract class AnimalAgressive<TEnemy, TAnimal> : AnimalAgressiveBase<TAnimal> where TEnemy : TAnimal
    {
        public abstract string BarkAtEnemy(TEnemy enemy);
        public string Bark(TAnimal animal)
        {
            return BarkAtEnemy((TEnemy)animal);
        }
    }
