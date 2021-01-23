    public partial class MainPage : PhoneApplicationPage
    {
        private readonly ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            for (int i = 0; i < 100; i++)
            {
                customers.Add(new Customer { Name =" Customer " + i });
            }
            lstbox.ItemsSource = customers;
        }
    }
    public class Customer : INotifyPropertyChanged
    {
        private string name;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value != this.name)
                {
                    this.name = value;
                    OnPropertyChanged();
                }
            }
        }
    }
