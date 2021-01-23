    private List<Type> Models = new List<Type>()
    {
        typeof(LineModel), typeof(LineDirectionModel), typeof(BusStopTimeModel), typeof(BusStopNameModel)
    };
    void SomeMethod()
    {
      MethodInfo genericFunction =Connection.GetType().GetMethod("CreateTable");
        
      foreach (Type model in Models) 
      {
        MethodInfo realFunction = genericFunction.MakeGenericMethod(model);
        var ret = realFunction.Invoke(Connection, new object[] {  });
      }
    }
