    public MyObject GetObject()
    {
        if (myObject == null)
        {
           lock(lockObject)
           {
              if (myObject == null)
              {
                  myObject = factory.Create();
              }
           }
        }
        return myObject;
    }
