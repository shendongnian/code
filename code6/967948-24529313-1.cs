    public void MyMethod(List<long> list)
    {
        // Do Something
    }
    
    public void MyMethod(long item)
    {
        MyMethod(new List<long>{ item });
    }
