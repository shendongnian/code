    public class MainViewModel : ViewModelBase
    {
        private string counterText;
        public string CounterText
        {
            get {return counterText; }
            set
            {
                counterText = value;
                RaisePropertyChanged();
            }
        }
        public MainViewModel()
        {
            Messenger.Default.Register<NotificationMessage<string>>(this, (m) => CounterText = m.Content);
        }
    }
