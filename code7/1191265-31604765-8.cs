    MyObject obj = new MyObject();
    Update(ref obj);
    public void Update(ref MyObject obj)
    {
        obj = new MyObject(); // changing the ref!!!
        obj.thisA = GetValue1();
    }
