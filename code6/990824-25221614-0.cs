    public partial class MainWindow : Window
	{
		private ICollection<TextChange> _latestChange = null;
		public MainWindow()
		{
			InitializeComponent();
			myTextBox.TextChanged += (o, a) =>
			{
				_latestChange = a.Changes;
			};
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (_latestChange != null)
			{
				var change = _latestChange.FirstOrDefault(); // Just take first change
				if (change.AddedLength > 0) // If text was removed, ignore
				{
					myTextBox.Text = myTextBox.Text.Remove(change.Offset, change.AddedLength);
				}
			}
		}
	}
