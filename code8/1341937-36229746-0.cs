    public IEnumerable<BaseClass> GetAllSelectedChildren(DerivedOne derivedOne)
    {
        derivedOne.Children.SelectMany(GetAllSelected);
    }
    public IEnumerable<BaseClass> GetAllSelected(BaseClass baseClass)
    {
        var selected = new List<BaseClass>();
        
        if(baseClass.IsSelected)
        {
            selected.Add(baseClass);
        }
    
        var derivedOne = baseClass as DerivedOne;
        if(derivedOne != null)
        {
            selected.AddRange(GetAllSelectedChildren(derivedOne));
        }
    
        return selected;
    }
