    private List<Type> Models = new List<Type>()
    {
        typeof(LineModel), typeof(LineDirectionModel), typeof(BusStopTimeModel), typeof(BusStopNameModel)
    };
    foreach (Type model in Models) // in code of my method
    {
        MethodInfo genericFunction =Connection.GetType().GetMethod("CreateTable");
        MethodInfo realFunction = genericFunction.MakeGenericMethod(model);
        var ret = realFunction.Invoke(Connection, new object[] {  });
    }
