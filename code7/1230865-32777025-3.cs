    public void MyMethod<T>(T myParameter) where T : class
    {
       Employee e;
       if((e = myParameter as Employee) != null)
       {
          //DO stuff with e
       }
    }
