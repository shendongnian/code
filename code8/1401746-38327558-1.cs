    [TestMethod, Isolated]
    public void InvokeEvent_willChangeWasCalledToTrue()
    {
        var p = new Program();
        bool wasCalled = false;
        p.PerformEvent += (s, e) => { wasCalled = true; };
        
        var args = Isolate.NonPublic.CreateInstance<ElapsedEventArgs>(0, 2);
    
        Isolate.Invoke.Event(() => p.PerformEvent += null, null, args);
    
        Assert.IsTrue(wasCalled);
    }
