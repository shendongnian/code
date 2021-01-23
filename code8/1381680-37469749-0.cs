    List<Pet> pets = new List<Pet>
    {
        new Cat("cat1", 1, "Happy"),
        new Cat("cat2", 2, "Happy"),
        new Dog("dog", 1, "Surly"),
        new Terrier("dog", 3, "Happy")
    };
    // in your Iterate() method
    foreach (var pet in pets)
    {
        // common methods here
        pet.MakeNoise();
        if (pet is Cat)
        {
            var animal = (Cat)pet;
            animal.ClimbTree();
        }
        else if (pet is Terrier)
        {
            var animal = (Terrier)pet;
            animal.Growl();
        }
    }
