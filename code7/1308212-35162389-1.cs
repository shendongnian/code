    [TestMethod]
    public void GetYearsTest(){
       //This would assume that your web api class has a mockable repository
       var yourClass = new YourClass(new MockRepository());
       //this is going to run your codes synchronously so you can get an immediate result to test on.
       var years = yourClass.GetYears().Result;
 
       //Run whatever test you want to on this
       Assert.IsNotNull(years);
            
    }
