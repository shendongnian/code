    [TestMethod]
    public void CallFakeJeepType_WillReturnWantedString()
    {
        var jeep = Isolate.Fake.Instance<Jeep>();
        Isolate.WhenCalled(() => jeep.Type).WillReturn("fake jeep");
    
        var result = Jeep.DoSomthing(jeep);
    
        Assert.AreEqual("fake jeep", result);
    }
     
