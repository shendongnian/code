    public class DataContextSpy : Freezable
	{
		public DataContextSpy ()
		{
			// This binding allows the spy to inherit a DataContext.
			BindingOperations.SetBinding (this, DataContextProperty, new Binding ());
		}
		public object DataContext
		{
			get { return GetValue (DataContextProperty); }
			set { SetValue (DataContextProperty, value); }
		}
		// Borrow the DataContext dependency property from FrameworkElement.
		public static readonly DependencyProperty DataContextProperty = FrameworkElement
			.DataContextProperty.AddOwner (typeof (DataContextSpy));
		protected override Freezable CreateInstanceCore ()
		{
			// We are required to override this abstract method.
			throw new NotImplementedException ();
		}
	}
