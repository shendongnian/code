    public partial class CarSelector : ITypeEditor
	{
		public CarSelector()
		{
			InitializeComponent();
		}
		public static readonly DependencyProperty ValueProperty = 
			DependencyProperty.Register("Value", typeof(ObservableCollection<string>), typeof(CarSelector),
				new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
		
		public string Value
		{
			get { return (string)GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); }
		}
		public FrameworkElement ResolveEditor(PropertyItem propertyItem)
		{
			var binding = new Binding("Value");
			binding.Source = propertyItem;
			binding.Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay;
			BindingOperations.SetBinding(this, ValueProperty, binding);
			return this;
		}
		private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (sender != null)
				MainWindow.Instance._properties.SelectedCar = (sender as ComboBox).SelectedItem as string;
		}
	}
