    [TestMethod]
    public void StringMethodsTest_DollarSign()
    {
        string name = "Forrest";
        string surname = "Gump";
        int year = 3; 
        string sDollarSign = $"My name is {name} {surname} and once I run more than {year} years."; 
        string expectedResult = "My name is Forrest Gump and once I run more than 3 years."; 
        Assert.AreEqual(expectedResult, sDollarSign);
    }
 
