        interface IPropertyInspector
        {
            PropertyInfo[] GetProperties(object obj);
        }
        class GenericPropertyInspector : IPropertyInspector { /* your current implementation */ }
        class StreamPropertyInspector : IPropertyInspector { /* does not return e.g. ReadTimeout if CanTimeout is false */ }
        Dictionary<Type, IPropertyInspector> inspectors = ...;
        inspectors[typeof(MemoryStream)] = new StreamPropertyInspector();
        ...
        Type t = objectToRegister.GetType();
        IPropertyInspector inspector;
        if (!inspectors.TryGetValue(t, out inspector))
        {
            inspector = new GenericPropertyInspector();
        }
        var properties = inspector.GetProperties(objectToRegister):
        // do something with properties
