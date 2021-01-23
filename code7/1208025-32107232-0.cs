    var binding = BindingOperations.GetBindingExpression(this, TextBox.TextProperty);
    PropertyInfo property = binding.DataItem.GetType().GetProperty(binding.ParentBinding.Path.Path);
    if (property != null)
        property.SetValue(binding.DataItem, String.IsNullOrWhiteSpace(text) ? null : text, null);
    binding.UpdateTarget();
