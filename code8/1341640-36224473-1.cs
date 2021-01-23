    [Test]
    public void PairsEqual()
    {
        var p1a = new Pair<int>(10, 1);
        var p1b = new Pair<int>(10, 1);
        var p2 = new Pair<int>(10, 2);
        var equals = GetValueTypeEquals();
        Assert.That(!equals(p1a,  p2));
        Assert.That(equals(p1a, p1a));
        Assert.That(equals(p1a, p1b));
    }
