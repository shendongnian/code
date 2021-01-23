    [Test]
    public void PerGraphLifeStyle()
    {
        var container = Build();
        C1 c1;
        C1 c2;
        using (var scope = container.BeginLifetimeScope("SomeTag"))
        {
            c1 = scope.Resolve<C1>();
            Assert.AreSame(c1.A, c1.B.A);
        }
        using (var scope = container.BeginLifetimeScope("SomeTag"))
        {
            c2 = scope.Resolve<C1>();
            Assert.AreSame(c1.A, c1.B.A);
        }
        Assert.AreNotSame(c1.A, c2.A);
    }
