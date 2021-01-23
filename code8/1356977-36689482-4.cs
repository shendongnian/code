    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private ObservableCollection<comboItem> comboitems = new ObservableCollection<comboItem>();
    
        private string _contenttext;
    
        public string contenttext
        {
            get
            {
                return _contenttext;
            }
            set
            {
                if (value != _contenttext)
                {
                    _contenttext = value;
                    OnPropertyChanged();
                }
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }
    
        private int daycount;
    
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            showdays();
        }
    
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            comboitems.Clear();
            comboitems.Add(new comboItem { dayofweek = "Sunday", ischecked = false });
            comboitems.Add(new comboItem { dayofweek = "Monday", ischecked = true });
            comboitems.Add(new comboItem { dayofweek = "Tuesday", ischecked = true });
            comboitems.Add(new comboItem { dayofweek = "Wednesday", ischecked = true });
            comboitems.Add(new comboItem { dayofweek = "Thursday", ischecked = true });
            comboitems.Add(new comboItem { dayofweek = "Friday", ischecked = true });
            comboitems.Add(new comboItem { dayofweek = "Saturday", ischecked = false });
        }
    
        private void comboBox_DropDownClosed(object sender, object e)
        {
            showdays();
        }
    
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBox.SelectedIndex = -1;
        }
    
        private void showdays()
        {
            contenttext = null;
            daycount = 0;
            for (int i = 0; i < comboBox.Items.Count(); i++)
            {
                comboItem item = comboBox.Items.ElementAt(i) as comboItem;
                if (item.ischecked)
                {
                    contenttext = contenttext + item.dayofweek.Substring(0, 3) + ", ";
                    daycount++;
                }
            }
    
            if (daycount != 0)
            {
                if (daycount == 2 && contenttext == "Sun, Sat, ")
                {
                    contenttext = "Weekends";
                }
                else if (daycount == 5 && contenttext == "Mon, Tue, Wed, Thu, Fri, ")
                {
                    contenttext = "Weekdays";
                }
                else if (daycount == 7)
                {
                    contenttext = "Every day";
                }
                else
                {
                    contenttext = contenttext.TrimEnd(' ', ',');
                }
            }
            else
            {
                contenttext = "Only once";
            }
        }
    
    }
