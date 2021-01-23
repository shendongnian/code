    private void CreateObject(ObservableCollection<MobileModelInfo> Source)
    {
        var gType = Source.GetType();
        string collectionFullName = gType.FullName;
        Type[] genericTypes = gType.GetGenericArguments();
        string className = genericTypes[0].Name;
        string classFullName = genericTypes[0].FullName;
        // Get the type contained in the name string
        Type type = Type.GetType(classFullName, true);
        // create an instance of that type
        object instance = Activator.CreateInstance(type);
        // List of Propery for the above created instance of a dynamic class
        List<PropertyInfo> oProperty = instance.GetType().GetProperties().ToList();
    }
