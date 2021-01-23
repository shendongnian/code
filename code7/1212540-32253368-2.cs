       public class Email : ViewModelBase
        {
            private bool _isRead;
            public bool IsRead
            {
                get { return _isRead; }
                set
                {
                    _isRead = value;
                    OnPropertyChanged("IsRead");
                }
            }
    
            public string Sender { get; set; }
            public string Subject { get; set; }
            public string Date { get; set; }
        }
