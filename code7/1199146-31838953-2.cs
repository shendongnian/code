    PropertyInfo property = typeof(AbstructHead).GetProperty("Int_toHide", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
    if (property == null) 
    {
        throw new ApplicationException("This version of AbstructHead does not have an Int_toHide property");
    }
  
    property.SetValue(this, value, null);
