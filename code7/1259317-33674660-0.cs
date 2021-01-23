    string str = "My Name is @MyClass.FirstName @MyClass.LastName";
    
    var me = new MyClass { FirstName = "foo", LastName = "bar" };
    
    foreach (var property in me.GetType().GetProperties())
    {
        var stringToReplace = "@" + me.GetType().Name + "." + property.Name;
        str = str.Replace(stringToReplace, property.GetValue(me).ToString());
    }
