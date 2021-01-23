    if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
    {
        var data = GetData(...);
        DataContext = new Storages(data) 
    }
