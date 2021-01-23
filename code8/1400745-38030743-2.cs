    // Running the method which returns List<string>
    Task<List<string>> result = Task.Factory.StartNew(() => ExpensiveMethod());
    
    public List<string> ExpensiveMethod()
    {
        return ...;
    }
