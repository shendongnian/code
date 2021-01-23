      public class Email:INotifyPropertyChanged
    {
        private bool _isRead;
        public bool IsRead
        {
            get { return _isRead; }
            set
            {
                _isRead = value;
                OnPropertyChanged();
            }
        }  
        private String _sender ;
        public String Sender
        {
            get
            {
                return _sender;
            }
            set
            {
                if (_sender == value)
                {
                    return;
                }
                _sender = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        
        private ObservableCollection<Email> _emailsCollection = new ObservableCollection<Email>(){new Email(){Sender = "FirstSender",IsRead = true},new Email(){Sender = "SecondSender",IsRead = false}};
       
        public ObservableCollection<Email> EmailsCollection
        {
            get
            {
                return _emailsCollection;
            }
            set
            {
                if (_emailsCollection == value)
                {
                    return;
                }
                _emailsCollection = value;
                OnPropertyChanged();
            }
        }
        private Email _selectedItem=new Email(){IsRead = true};
        public Email SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                _selectedItem.IsRead = true;
                OnPropertyChanged();
            }
        }
        public MainWindow()
        {
            InitializeComponent();            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
