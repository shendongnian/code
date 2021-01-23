    public void UpdateCollection(Order[] orderCollection)
    {
        foreach(Order o in orderCollection)
              Update(o);
    }
    
    public void Update(MyObject object)
    {
        object.thisA = GetValue1();
    }
