    public class ChannelViewModel : INotifyPropertyChanged
    {
        private string _name = "";
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(Name)));
            }
        }
        private int _channel = 0;
        public int Channel
        {
            get { return _channel; }
            set
            {
                _channel = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(Channel)));
            }
        }
        private int _value = 0;
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                K8055.OutputAnalogChannel(Channel, Value);
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(Value)));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            Channels.Add(new ChannelViewModel { Name="Fred", Channel = 1, Value = 3 });
            Channels.Add(new ChannelViewModel { Name="Bob", Channel = 2, Value = 35 });
        }
        public ObservableCollection<ChannelViewModel> Channels { get; private set; }
            = new ObservableCollection<ChannelViewModel>();
        public event PropertyChangedEventHandler PropertyChanged;
    }
