    if (prop.PropertyType.Name == "ObservableCollection`1")
    {
        Type type = prop.PropertyType;
        var property = (t.GetProperty(prop.Name)).GetValue(viewModel);
    
        // cast property as an ObservableCollection<object>
        var col = new ObservalbeCollection<object>(property);
        // if the example above fails you need to cast the property
        // from 'object' to an ObservableCollection<T> and then execute the code above
        // to make it clear:
        var mecol = new ObservableCollection<object>();
        ICollection obscol = (ICollection)property;
        for(int i = 0; i < obscol.Count; i++)
        {
            mecol.Add((object)obscol[i]);
        }    
        // the example above can throw some exceptions but it should work in most cases
    }
