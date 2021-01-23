    public List<TestClass> GetTestClass(string value, string AccountName)
    {
         foreach(TestClass test in yourListOfTestClass)
           {
             if (test.GetType().GetProperty(property).GetValue(test, null).Equals(value))
                 listToReturn.Add(test);
           }
        return listToReturn
     }
