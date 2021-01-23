    foreach (var prop in viewModel.GetType().GetProperties())
    {    
        if (prop.PropertyType.IsGenericType && 
            prop.PropertyType.GetGenericTypeDefinition() == typeof(ObservableCollection<>))
        {
            var values = (IEnumerable)prop.GetValue(viewModel);
            // cast property as an ObservableCollection<object>
            var collection = new ObservableCollection<object>(values.OfType<object>());
        }
    }
