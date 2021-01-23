    class SomeTabPageViewModel: INotifyPropertyChanged
    {
        ...
        string _someText;
        int _someTextChanged = 0; // how many times text was changed by user
        public string SomeText
        {
            get { return _someText; }
            set
            {
                _someText = value;
                _someTextChanged++; // when TextBox lost focus after user changed value
                OnPropertyChanged();
            }
        }
    }
