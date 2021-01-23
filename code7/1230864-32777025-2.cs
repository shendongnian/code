    public void MyMethod<T>(T myParameter) where T : class
    {
       if(myParameter is Employee)
       {
          // we can use 'as' operator because T is class
    
          Employee e = myParameter as Employee;
          //DO stuff
       }
    }
