    var values = viewModel.GetType().GetProperties()
        .Where(p => p.PropertyType.IsGenericType)
        .Where(p => p.PropertyType.GetGenericTypeDefinition() == typeof(ObservableCollection<>))
        .Select(p => (IEnumerable)p.GetValue(viewModel))
        .SelectMany(e => e.OfType<object>());
    var collection = new ObservableCollection<object>(values);
   
