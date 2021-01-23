    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Email> EmailsCollection { get; private set; }
        private Email _selectedItem;
        public Email SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                if (_selectedItem.IsRead) return;
                if (value != null)
                {
                    EmailsCollection[EmailsCollection.IndexOf(value)].IsRead = true;
                }
            }
        }
        public MainViewModel() 
        {
            EmailsCollection = new ObservableCollection<Email>()
            {      
                new Email
                {
                    Sender = "Sender",
                    Subject = "Subject",
                    Date = "Date"
                },
                new Email
                {
                    Sender = "Sender1",
                    Subject = "Subject1",
                    Date = "Date1"
                },
                new Email
                {
                    Sender = "Sender2",
                    Subject = "Subject2",
                    Date = "Date2"
                }
            };
        }
    }
