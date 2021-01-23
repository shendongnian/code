    [Test]
    public void CreateEntityWithNavigationProperty()
    {
        var fixture = new Fixture();
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    
        var dog = fixture.Create<Dog>();
    
        Assert.That(dog.PetOwner, Is.Not.Null);
        Assert.That(dog.PetOwner.Dogs, Is.Empty);
    }
