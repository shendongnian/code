    public void Generalized(ICollection<string> collection)
    {
        //blah
    }
    public void Specialized(List<string> collection)
    {
        //blah
    }
    public void SomeOtherMethod()
    {
        ICollection<string> coll = new List<string> { "a", "b" };
        List<string> list = new List<string> { "a", "b" };
        Generalized(coll);
        Generalized(list);
        Specialized(list);
        Specialized(coll); //doesn't compile
    }
