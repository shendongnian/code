	this.Loaded += (sender, args) =>
	{
		var binding = BindingOperations.GetBinding(this, ValueProperty);
		if (binding != null)
		{
			BindingOperations.SetBinding(ButtonEdit, DevExpress.Xpf.Editors.TextEditBase.TextProperty, binding);
		}
	};
