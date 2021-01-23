    private Dictionary<Type, Action<ISomething>> _TypeResolver = new Dictionary<Type, Action<ISomething>>();
    private void InitializeTypeResolver()
    {
        _TypeResolver.Add(typeof(Something<int>), ForInteger);
        _TypeResolver.Add(typeof(Something<double>), ForDouble);
    }
    private void ForInteger(ISomething source)
    {
        // We know, we will only be called for this specific type, so a hard cast is the way to go.
        var something = (Something<int>)source;
        var value = something.Value; // Will be of type int.
        // ToDo: Whatever you want with that integer.
    }
    private void ForDouble(ISomething source)
    {
         var something = (Something<double>)source;
         var value = something.Value; // Will be of type double.
    }
    private void Resolve(ISomething something)
    {
         // ToDo: nullity checks.
         Action<ISomething> action;
         if(_TypeResolver.TryGetValue(something.GetType(), out action))
         {
             action(something);
         }
         else
         {
             // ToDo: What shall we do with the drunken sailor (or unknown type)?             
         }
    }
