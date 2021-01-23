	namespace WpfApplication1
	{
		/// <summary>
		/// Interaction logic for MainWindow.xaml
		/// </summary>
		public partial class MainWindow : Window
		{
			public MainWindow()
			{
				InitializeComponent();
			}
		}
		public class ViewModel : ViewModelBase
		{
			private string _currentTime;
			public DispatcherTimer _timer;
			public string CurrentTime
			{
				get
				{
					return this._currentTime;
				}
				set
				{
					if (_currentTime == value)
						return;
					_currentTime = value;
					OnPropertyChanged("CurrentTime");
				}
			}
			public ViewModel()
			{
				_timer = new DispatcherTimer(DispatcherPriority.Render);
				_timer.Interval = TimeSpan.FromSeconds(1);
				_timer.Tick += (sender, args) =>
							   {
								   CurrentTime = DateTime.Now.ToLongTimeString();
							   };
				_timer.Start();
			}
		}
		public class ViewModelBase : INotifyPropertyChanged
		{
			public event PropertyChangedEventHandler PropertyChanged;
			[NotifyPropertyChangedInvocator]
			protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
			{
				var handler = PropertyChanged;
				if (handler != null)
				{
					handler(this, new PropertyChangedEventArgs(propertyName));
				}
			}
		}
	}
