    [Test]
    public void Proof()
    {
        Dog dog = new Dog()
        {
            Name = "Woofy",
            HadWalkToday = true
        };
        Cat cat = new Cat()
        {
            Name = "Fluffy",
            ColorOfWhiskers = "Brown"
        };
        IList<Animal> animals = new List<Animal>()
        {
            dog,
            cat
        };
    
        string json = JsonConvert.SerializeObject(animals);
        IList<Animal> result = JsonConvert.DeserializeObject<List<Animal>>(json);
    
        Assert.IsTrue(result[0].GetType() == typeof(Dog));
        Assert.IsTrue(result[1].GetType() == typeof(Cat));
    }
