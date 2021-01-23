    public class Farm
    {
        private readonly IMammal[] _animals;
    
        public Farm(IMammal[] animals)
        {
            _animals = animals;
        }
    
        public void Feed()
        {
           foreach (var animal in _animals)
                animal.Eat();
        }
    
        public IBarking GuardingAnimal { get; set; }
    
        public void Guard()
        {
            if (GuardingAnimal != null)
                GuardingAnimal .Bark();
        }
    }
