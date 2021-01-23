    public MyObject GetObject()
    {
        if (myObject == null)
        {
           lock(lockObject)
           {
              if (myObject == null)
              {
                  myObject = factory.Create();
                 //need forcibly sync myObject value beetween all threads here
              }
           }
        }
        return myObject;
    }
