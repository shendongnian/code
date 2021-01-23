    var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.GetInterfaces().Contains(typeof(ISomething))
                         && t.GetConstructor(Type.EmptyTypes) != null
                select Activator.CreateInstance(t) as ISomething;
    foreach (var instance in instances)
    {
        instance.CallMe(); // where CallMe is a method of ISomething
    }
