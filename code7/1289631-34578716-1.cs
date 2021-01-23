    public class SomeTemplateViewModel : ViewModelBase
    {
        private double _value;
        public SomeTemplateViewModel()
        {
            ValueChangedCommand = new RelayCommand<RoutedPropertyChangedEventArgs<double>>(
                args => Value = args.NewValue);
        }
        public ICommand ValueChangedCommand { get; set; }
        public double Value
        {
            get { return _value; }
            set { _value = value; RaisePropertyChanged(); }
        }
    }
