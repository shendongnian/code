    public interface TestA
    {
        string GetName();
        string GetLastName();
    }
    public interface TestB
    {
        string GetFullName();
    }
    
    public interface Test : TestA, TestB
    {        
    }
