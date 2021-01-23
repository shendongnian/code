    public delegate void SetControlPropertyDelegateHandler(Control control, string propertyName, object value);
    public static void SetControlProperty(Control control, string propertyName, object value)
    {
     if (control == null) 
         return;
     if (control.InvokeRequired)
     {
        SetControlPropertyDelegateHandler dlg = new SetControlPropertyDelegateHandler(SetControlProperty);
        control.Invoke(dlg, control, propertyName, value);
     }
     else
     {
        PropertyInfo property = control.GetType().GetProperty(propertyName);
        if (property != null)
            property.SetValue(control, value, null);
     }
    }
