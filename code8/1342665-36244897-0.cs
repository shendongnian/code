     [TestMethod, Isolated]
     public void TestRun()
     {
        //Arrange
        var fake = Isolate.Fake.Instance<ITest>();
        Isolate.WhenCalled(() => fake.Run()).CallOriginal();
    
        //Act
        fake.Run();
    
        //Assert
        Isolate.Verify.WasCalledWithAnyArguments(() => fake.Run());
    }
