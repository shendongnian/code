    [Test]
    public void CreateEntityWithNavigationProperty()
    {
        var fixture = new Fixture();
        fixture.Customize<PetOwner>(c =>
            c.With(owner => owner.Dogs, Enumerable.Empty<Dog>()));
    
        var dog = fixture.Create<Dog>();
    
        Assert.That(dog.PetOwner, Is.Not.Null);
        Assert.That(dog.PetOwner.Dogs, Is.Empty);
    }
