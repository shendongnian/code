    static void Main(string[] args)
    {
        List<IAnimal> animals = GetAllZooAnimals();
        foreach (IAnimal animal in animals)
            ProcessAnimal(animal);
    }
    static void ProcessAnimal(IAnimal animal)
    {
         Console.WriteLine(animal.GetDescription());
    }
