    public TestClass[] GetTestClass(string value, string AccountName)
    {
        var propertyInfo = typeof(TestClass).GetProperty(AccountName);
        var list = new List<TestClass>();
        foreach(var tc in [YOUR_OBJECTS])
        {
            if(propertyInfo.GetValue(tc, null) == value)
            {
                list.add(tc);
            }
        }
        return list.ToArray();
    }
