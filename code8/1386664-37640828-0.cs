    [Fact]
    public void CreateSmallTree()
    {
        var fixture = new Fixture();
        fixture.Behaviors
            .OfType<ThrowingRecursionBehavior>()
            .ToList()
            .ForEach(b => fixture.Behaviors.Remove(b));
        fixture.Behaviors.Add(new OmitOnRecursionBehavior(recursionDepth: 2));
        var xce = fixture.Create<XmlCommandElement>();
        Assert.NotEmpty(xce.Commands);
    }
