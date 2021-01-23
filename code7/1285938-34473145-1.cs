    var subClass = obj as SubClass;
    if ( subClass != null )
    {
        var type = subClass.GetType();
        var props = type.GetProperties();
        ...
    }
