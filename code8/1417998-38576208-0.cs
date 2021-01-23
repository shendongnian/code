    public class ViewModel : INotifyPropertyChanged
    {
        private string _textFieldValue;
        public string TextFieldValue {
            get
            {
                return _textFieldValue;
            }
            set
            {
                _textFieldValue = value;
                NotifyChanged();
            }
        }
        public void NotifyChanged()
        {
            if (PropertyChanged != null) PropertyChanged(this, null);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
