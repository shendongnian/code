	public static class DataBindingUtils
	{
		public static void RefreshBindings(this BindingContext context, object dataSource)
		{
			foreach (var binding in context[dataSource].Bindings.Cast<Binding>())
				binding.ReadValue();
		}
	}
