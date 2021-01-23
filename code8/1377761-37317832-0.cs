    [TestMethod]
    [ExpectedException(typeof(<The specific exception>))]
    public void FooTest()
    {
        //arrange
        
        try
        {
           // act
        }
        catch(<the specific exception>)
        {
           // some asserts
           throw;
        }
    }
