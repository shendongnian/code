    private void GenericTest<T>(IEnumerable<T> inputs)
    {
        MethodInfo property = typeof(T).GetProperty(/*YOUR PROPERTY*/).GetMethod;
        foreach (var input in inputs)
        {
            object value = property.Invoke(input, null);
            // Logic
        }
    }
    
    // To protect it from error
    public void Test(IEnumerable<TypeA> inputs)
    {
        GenericTest(inputs);
    }
    // To protect it from error
    public void Test(IEnumerable<TypeB> inputs)
    {
        GenericTest(inputs);
    }
