    [TestMethod]
    public async Task TestingMyClassThreadSync()
    {
        int repeatTimes = 100;
    
        int counter = 0;
        while (counter++ <= repeatTimes)
        {
            MyClass myClass = new MyClass();
    
            Task tA = myClass.MethodA();
    
            Task tB = myClass.MethodB();
    
            Task finishedTask = await Task.WhenAny(tA, tB);
    
            bool bFinishedBeforeA = finishedTask == tA;
    
            if (bFinishedBeforeA)
                Assert.Fail();
        }
    
    }
