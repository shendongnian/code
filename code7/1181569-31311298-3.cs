    [Test]
    public void TestMethod1()
    {
        //Arrange
        var myClass = new MyClass();
        var expectedVarList = new List<int> {1,2,3};
    
        Isolate.NonPublic.WhenCalled(myClass, "MyPrivateMethod")
            .AssignRefOut(expectedVarList, 0.0)
            .IgnoreCall();
    
        //Act
        var resultVarList = myClass.MyMethod(0, 0);
    
        //Assert
        CollectionAssert.AreEqual(expectedVarList, resultVarList);
    
    }
