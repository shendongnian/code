    public void SetReportObject( object obj )
    {
        if(obj == null) throw new ArgumentNullException("obj");
        PropertyInfo textProperty = obj.GetType().GetProperty("Text");
        if(textProperty == null) throw new InvalidOperationException("The control must have a Text property");
        if(!textProperty.CanWrite) throw new InvalidOperationException("The control must have a setteable Text property");
        textProperty.SetValue(obj, "0%", null);
    }
