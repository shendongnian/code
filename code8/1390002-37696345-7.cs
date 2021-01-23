    public EvoObject(Object id, 
                     List<Dictionary<Int32, Int32>> papers, 
                     List<Int32> coAuthors, 
                     List<Int32> venues)
    {
        // all constructor logic goes in one constructor
    }
    public EvoObject(Object id, 
                     List<Dictionary<Int32, Int32>> papers, 
                     List<Int32> coAuthors)
        :this(id, papers, coAuthors, null)
    {
        // nothing else here
    }
