    public void X(int i2, ref MyInt i1)
    {
       // When you define a ref parameter
       // you're not creating a new reference but you're
       // reusing the given one
       i1 = i2;
    }
    
    MyInt i1 = 4;
    MyInt i2 = 0;     
    
    // This would produce what you expect
    X(i2, ref i1);
    // Now i2 is 4
