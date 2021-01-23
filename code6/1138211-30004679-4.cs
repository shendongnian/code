    var t = Type.GetType(setting.PropertyType.FullName);
    if (SettingsDictionary.ContainsKey(setting.Name))
    {
        value.SerializedValue = SettingsDictionary[setting.Name].value;
        // value.PropertyValue = Convert.ChangeType(SettingsDictionary[setting.Name].value, t);
        value.PropertyValue = getPropertyValue(SettingsDictionary[setting.Name].value, t, setting.SerializeAs);
    }
    else //use defaults in the case where there are no settings yet
    {
        value.SerializedValue = setting.DefaultValue;
        //   value.PropertyValue = Convert.ChangeType(setting.DefaultValue, t);
        value.PropertyValue = getPropertyValue((string)setting.DefaultValue, t, setting.SerializeAs);
    }
    
