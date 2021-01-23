    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            SelectedOperator = "=";
        }
        private string _selectedOperator;
        public string SelectedOperator
        {
            get { return _selectedOperator; }
            set { _selectedOperator = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
