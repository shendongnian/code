    private String GetDescription(FrameworkElement element)
    {
        var decProp= element.DataContext.GetType().GetProperty("Description");
        return decProp!=null
               ?decProp.GetValue(element.DataContext)
               :"";
    }
