    namespace SilverlightApplication1
    {
    	public partial class MainPage : UserControl
    	{
    		public MainPage()
    		{
    			InitializeComponent();
    			DataContext = new ViewModel();
    		}
    	}
    
    	public class ViewModel: INotifyPropertyChanged
    	{
    		private DateTime _currentDateTime;
    		public DateTime CurrentDateTime
    		{
    			get { return _currentDateTime; } 
    			set { 
    				_currentDateTime = value;
    				OnPropertyChanged("CurrentDateTime");
    			}
    		}
    
    		public event PropertyChangedEventHandler PropertyChanged;
    
    		protected virtual void OnPropertyChanged(string propertyName)
    		{
    			PropertyChangedEventHandler handler = PropertyChanged;
    			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    		}
    
    		public ViewModel()
    		{
    			CurrentDateTime = DateTime.Now;
    		}
    	}
    }
