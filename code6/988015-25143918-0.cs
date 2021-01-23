    public partial class MainWindow : Window, INotifyPropertyChanged
    {
		private Thickness _margin = new Thickness(100, 20, 0, 0);
		public Thickness GridMargin
		{
			get { return _margin; }
			set
			{
				_margin = value;
				//Notify the binding that the value has changed.
				this.OnPropertyChanged("GridMargin");
			}
		}
		public MainWindow()
		{
			InitializeComponent();
			No.DataContext = this;
		}
		protected void OnPropertyChanged(string strPropertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(strPropertyName));
		}
		#region INotifyPropertyChanged Members
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion
		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			Random r = new Random();
			GridMargin = new Thickness(r.Next(0, 100));
		}
	}
