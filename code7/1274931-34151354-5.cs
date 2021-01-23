    public delegate object GetControlPropertyValueDelegate(Control controlToModify, string propertyName);
    public static T GetControlPropertyValue<T>(Control controlToModify, string propertyName)
    {
        if (controlToModify.InvokeRequired)
        {
            var dlg = new GetControlPropertyValueDelegate(GetControlPropertyValue);
            return (T)controlToModify.Invoke(dlg, controlToModify, propertyName);
        }
        else
        {
            var prop = controlToModify.GetType().GetProperty(propertyName);
            if (prop != null)
            {
                return (T)Convert.ChangeType(prop.GetValue(controlToModify, null), typeof(T));
            }
        }
        return default (T);
     }
