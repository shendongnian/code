    public Action<DataItem> Convert(Action<DomItem> action)
    {
        return new Action<DataItem>(o => action(Map(o)));
    }
    
    public DomItem Map(DataItem dataItem)
    {
        return new DomItem{Name = dataItem.Name};
    }
  
