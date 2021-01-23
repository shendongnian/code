    class Animal
    {
        public int Weight { get; set; }
        public int NumberOfLegs { get; set; }
    }
    
    ...
    
    public IEnumerable<Animal> TakeFive(IEnumerable<Animal> animals)
    {
        return animals.Take(5);
    }
