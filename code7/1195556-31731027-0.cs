    var type = Type.GetType("MyNamespace.StudentDatabase");
    if (type != null)
    {
        var field = type.GetField("avgHeight");
        if (field != null)
        {
            Func<bool> lambda = () => (double)field.GetValue(type) > 1.7;   
        }
    }
