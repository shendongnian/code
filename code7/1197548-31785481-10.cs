    public String GetDescription(this FrameworkElement element)
    {
        var contextData= element.DataContext as IDescribable;
        return contextData!=null
               ? contextData.Description
               :"";
    }
    
