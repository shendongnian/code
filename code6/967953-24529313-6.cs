    public void MyMethod(List<long> list)
    {
        // Do something
    }
    
    public void MyMethod(long item)
    {
        MyMethod(new List<long>{ item });
    }
