    [TestMethod]
    void AddRangeReturns0ForFailedAdd()
    {
        var foo = new Foo();
        Assert.AreEqual(0, foo.AddRange(new Fail(), 0));
        Assert.AreEqual(0, foo.AddRange(new Fail(), 1));
        Assert.AreEqual(0, foo.AddRange(new Fail(), 100));
    }
    class Fail : IMyInterface
    {
         public bool Add() { return false; }
         public bool Remove() { return false; }
         public bool Save() { return false; }
    }
