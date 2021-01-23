    public void MyMethod<T>(T myParameter) where T : struct
    {
       if(myParameter is int)
       {
          // we cant use 'as' operator here because ValueType cannot be null
          // explicit conversion doesn't work either because T could be anything so :
          int e = Convert.ToInt32(myParameter); 
          //DO stuff
       }
    }
