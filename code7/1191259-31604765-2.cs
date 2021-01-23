    MyObject obj = new MyObject();
    Update(ref obj);
    public void Update(ref MyObject object)
    {
        object = new MyObject(); // changing the ref!!!
        object.thisA = GetValue1();
    }
