   	class Conv : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((Func<string>)value)();
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			var binding = new Binding
			{
				Source = (Func<string>)AllelePopulation,
				Mode = BindingMode.OneWay,
				Converter = new Conv()
			};
			textBox.SetBinding(TextBox.TextProperty, binding);
		}
		private string AllelePopulation()
		{
			return "test";
		}
	}
