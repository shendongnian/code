    var prop = viewModel.GetType("ObservableCollection`1");
    var type = prop.PropertyType;
    var propertyValue = (t.GetProperty(prop.Name)).GetValue(viewModel);
    // cast property as an ObservableCollection<object>
    var myCollection = new ObservableCollection<object>(
                       ((ICollection)propertyValue).Cast<object>());
    }
