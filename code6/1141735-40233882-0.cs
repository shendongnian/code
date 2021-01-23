    private class MySingleton
    {
        public static MySingleTon GetInstance()
        {
            if (theOneAndOnlyInstance == null)
            {
                theOneAndOnlyInstance = new MySingleton(...);
            }
            return theOneAndOnlyInstance;
        }
        private static MySingleton theOneAndOnlyInstance = null;
        private MySingleton(...)
        {
            ... // initialize the non-static test variables
        }
        #region test variables
        public int TestVariableX {get; set;}
        ...
        #endregion test variables
    }
    [TestMethod}
    public void MyTest()
    {
        var myTestVariables = MySingleton.GetInstance(); 
        ...
    }
