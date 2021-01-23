    public class MultiCommandViewModel : INotifyPropertyChanged
    {
        private object value;
        private ICommand selectedCommand;
        public MultiCommandViewModel()
        {
            SetValueToXCommand = new RelayCommand((obj) => setValue(obj), (obj) => true);
            SetValueToNameCommand = new RelayCommand((obj) => setValue("Michael"), (obj) => true);
            SetValueTo1000Command = new RelayCommand((obj) => setValue(1000), (obj) => true);
            SetSelectedCommand = new RelayCommand((obj) => SelectedCommand = obj as ICommand, (obj) => true);
        }
        private void setValue(object obj)
        {
            Value = obj;
            SelectedCommand = null;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public object Value
        {
            get { return value; }
            set
            {
                this.value = value;
                Notify();
            }
        }
        public ICommand SelectedCommand
        {
            get { return (selectedCommand == null) ? SetValueToNameCommand : selectedCommand; }
            set
            {
                selectedCommand = value;
                Notify();
            }
        }
        public RelayCommand SetValueToXCommand { get; private set; }
        public RelayCommand SetValueToNameCommand { get; private set; }
        public RelayCommand SetValueTo1000Command { get; private set; }
        public RelayCommand SetSelectedCommand { get; private set; }
    }
