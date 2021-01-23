    public class ClassUnderTest
    {
        public void OutputANumber(out int number)
        {
            number = 3;
        }
    }
    
    [TestMethod, Isolated]
    public void TestOutSequence()
    {
        //Arrange
        var n = new ClassUnderTest();
    
        int number = 1;
        Isolate.WhenCalled(() => n.OutputANumber(out number)).IgnoreCall();
        number = 2;
        Isolate.WhenCalled(() => n.OutputANumber(out number)).IgnoreCall();
        Isolate.WhenCalled(() => n.OutputANumber(out number)).CallOriginal();
    
        //Act
        var res1 = 0;
        var res2 = 0;
        var resOriginal = 0;
        var resDefault = 0;
        n.OutputANumber(out res1);
        n.OutputANumber(out res2);
        n.OutputANumber(out resOriginal);
        n.OutputANumber(out resDefault);
          
        //Assert
        Assert.AreEqual(1, res1);
        Assert.AreEqual(2, res2);
        Assert.AreEqual(3, resOriginal);
        Assert.AreEqual(3, resDefault);
    }
