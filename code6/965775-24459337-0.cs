    [Test]
    public void MyTest_with_List()
    {
        var messages = new List<bool>();
        var x = new Subject<bool>();
        x.Subscribe(messages.Add);
        // Send the first bool
        x.OnNext(true);
        Assert.AreEqual(true, messages.Single());
    }
