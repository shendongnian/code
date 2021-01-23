    public class UserProfile : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        string user_first_name;
        public String UserFirstName
        {
            get { return user_first_name; }
            set
            {
                user_first_name = value;
                OnPropertyChanged("UserFirstName");
            }
        }
    
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    
    }
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
    
            UserProfile up = new UserProfile();
            this.tb1.DataContext = up;
            this.tb2.DataContext = up;
        }
     }
