    public ICollection<string> ReturnGeneralized()
    {
        return new List<string>();
    }
    public List<string> ReturnSpecialized()
    {
        return new List<string>();
    }
    static void SomeOtherMethod()
    {
        ICollection<string> coll1 = ReturnGeneralized();
        List<string> list1 = ReturnGeneralized(); //doesn't compile
        ICollection<string> coll2 = ReturnSpecialized();
        List<string> list2 = ReturnSpecialized();
    }
