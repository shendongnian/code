    public void ComponentNotLoaded(string userName, string machineName, string componentName)
    {
        if(IsEnabled())
            WriteEvent(2, userName, machineName, componentName);
    }
