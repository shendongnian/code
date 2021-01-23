    else if (dataBasePropInfo.PropertyType.IsGenericType)
    {
        var args = dataBasePropInfo.PropertyType.GetGenericArguments();
        var lstType = typeof (List<>).MakeGenericType(args);
        if (lstType.IsAssignableFrom(dataBasePropInfo.PropertyType))
        {
            PropertyInfo modelPropInfo = modelObjectType.GetProperty(dataBasePropInfo.Name);
            var target = Activator.CreateInstance(lstType);
            var source = modelPropInfo.GetValue(modelObject);
            lstType.InvokeMember("AddRange", BindingFlags.InvokeMethod, null, target, new[] {source});
    
            dataBasePropInfo.SetValue(dataBaseObject, target);
        }
        else
        {
            UpdateObjectFrom(dataBasePropInfo.GetValue(dataBaseObject, null), modelObjectType.GetProperty(dataBasePropInfo.Name).GetValue(modelObject, null));
        }
    }
