    class MainViewModel : FrameworkElement, INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaiseEvent(new RoutedEventArgs(TooltipChangedEvent));
                OnPropertyChanged();
            }
        }
        public static readonly RoutedEvent TooltipChangedEvent = EventManager.RegisterRoutedEvent("ToolTipChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<string>), typeof(Control));
        public event RoutedPropertyChangedEventHandler<string> ToolTipChanged
        {
            add
            {
                AddHandler(TooltipChangedEvent, value);
            }
            remove
            {
                RemoveHandler(TooltipChangedEvent, value);
            }
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
