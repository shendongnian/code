    private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
    {
        _textBoxes = FindAllTextBoxs(this);
         
        var vm = DataContext as ViewModelBase;
        if (vm != null) vm.UpdateAllValidationsEvent += OnUpdateAllValidationsEvent;
         
        foreach (var textbox in _textBoxes)
        {
            var binding = BindingOperations.GetBinding(textbox, TextBox.TextProperty);
         
            if (binding != null)
            {
                var property = binding.Path.Path;
                var validationEntity = new ValidationEntity {Key = property};
                binding.ValidationRules.Add(validationEntity);
                validationEntity.ValidationChanged += OnValidationChanged;
            }
        }
    }
    private List<TextBox> FindAllTextBoxs(DependencyObject fe)
    {
        return FindChildren<TextBox>(fe);
    }
         
    private List<T> FindChildren<T>(DependencyObject dependencyObject)
                where T : DependencyObject
    {
        var items = new List<T>();
         
        if (dependencyObject is T)
        {
            items.Add(dependencyObject as T);
            return items;
        }
         
        var count = VisualTreeHelper.GetChildrenCount(dependencyObject);
        for (var i = 0; i < count; i++)
        {
            var child = VisualTreeHelper.GetChild(dependencyObject, i);
            var children = FindChildren<T>(child);
            items.AddRange(children);
        }
        return items;
    }
