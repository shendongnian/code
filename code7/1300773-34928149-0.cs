	public class YourViewModel : INotifyPropertyChanged {
		private String _textContent;
		public String TextContent {
			get {return _textContent;}
			set {
				_textContent = value;
				OnPropertyChanged("TextContent");
			}
		}
		private DelegateCommand _cmdAddTextToChat;
	    /// <summary>
	    /// Add text to TextContent
	    /// </summary>
	    public DelegateCommand CmdAddTextToChat {
	        get { return _cmdAddTextToChat ?? (_cmdAddTextToChat = new DelegateCommand(AddTextToChat)); }
	    }
	    private void AddTextToChat(Object parameter) {
	        TextContent += (String)parameter;
	    }
		public event PropertyChangedEventHandler PropertyChanged;
	    private void OnPropertyChanged(string propertyName) {
	        var handler = PropertyChanged;
	        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
	    }
	}
	public partial class MainWindow : Window
    {
    	private YourViewModel _vm = new YourViewModel ();
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(string txtContext)
        {
            InitializeComponent();
            _vm.TextContent = txtContext;
            ClientWindow window = new ClientWindow() {DataContext = _vm};
        }
        private void btnMakeClient_Click(object sender, RoutedEventArgs e)
        {            
            ClientWindow window = new ClientWindow() {DataContext = _vm};
            window.Show();
        }
    }
	public partial class ClientWindow : Window
	    public ClientWindow()
	    {
	        InitializeComponent();  
	    }
	}
