    public class MyControl : UserControl
	{
		public MyControl()
		{
			BindingOperations.SetBinding( this, MyControl.ObservedDataContextProperty, new Binding() );
		}
		public object ObservedDataContext
		{
			get { return (object) GetValue( ObservedDataContextProperty ); }
			set { SetValue( ObservedDataContextProperty, value ); }
		}
		public static readonly DependencyProperty ObservedDataContextProperty =
			DependencyProperty.Register( "ObservedDataContext", typeof( object ), typeof( MyControl ), new PropertyMetadata( null, OnObservedDataContextChanged ) );
		private static void OnObservedDataContextChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
		{
			((MyControl) d).OnObservedDataContextChanged();
		}
		private void OnObservedDataContextChanged()
		{
			RaiseDataContextChanged();
		}
		private void RaiseDataContextChanged()
		{
			var h = DataContextChanged;
			if (h != null) h( this, EventArgs.Empty );
		}
		public event EventHandler DataContextChanged;
	}
