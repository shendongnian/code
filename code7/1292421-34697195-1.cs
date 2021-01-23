	public class BindingProxy : Freezable
	{
		protected override Freezable CreateInstanceCore()
		{
			return new BindingProxy();
		}
		public object Data
		{
			get { return GetValue(DATA_PROPERTY); }
			set { SetValue(DATA_PROPERTY, value); }
		}
		// Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty DATA_PROPERTY =
			DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
	}
