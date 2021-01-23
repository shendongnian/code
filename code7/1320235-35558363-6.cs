    [Fact]
    public void CreateFoos()
    {
        var fixture = new Fixture().Customize(new FooCustomization());
        fixture.Behaviors.Add(new TracingBehavior());
    
        var foos = fixture.CreateMany<Foo>();
        Assert.True(
            foos.All(f => f
                .Descriptions
                .Select(x => x.LanguageId)
                .Distinct()
                .Count() == f.Descriptions.Count),
            "Languaged IDs should be unique for each foo.");
    }
