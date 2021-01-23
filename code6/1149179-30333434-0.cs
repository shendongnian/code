    static void SetValueByPath(object target, string path, object value)
    {
        int dotIndex = path.IndexOf('.');
        string targetProperty = dotIndex > 0 ?
            targetProperty = path.Substring(0, dotIndex) : path;
        FieldInfo fieldInfo = target.GetType().GetTypeInfo().GetDeclaredField(targetProperty);
        if (dotIndex > 0)
        {
            object currentValue = fieldInfo.GetValue(target);
            SetValueByPath(currentValue, path.Substring(dotIndex + 1), value);
            value = currentValue;
        }
        fieldInfo.SetValue(target, value);
    }
