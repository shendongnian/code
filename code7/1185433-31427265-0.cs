    var prop = Model.GetType().GetProperty("ID");
    var propValue = Convert.ChangeType(s1, types[0]);
    if (prop != null && prop.CanWrite)
    {
        prop.SetValue(Model, propValue, null);
    }
