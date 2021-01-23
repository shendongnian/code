        public string SelectedConMode { get; set; }
        private bool? _isFoodProperty;
        public bool? IsFoodProperty
        {
            get { return _isFoodProperty; }
            set
            {
                _isFoodProperty = value;
                if (value != null && (bool)value)
                    SelectedConMode = "Food";
            }
        }
        private bool? _isDrinkProperty;
        public bool? IsDrinkProperty
        {
            get { return _isDrinkProperty; }
            set
            {
                _isDrinkProperty = value;
                if (value != null && (bool)value)
                    SelectedConMode = "Drinks";
            }
        }
        private string _selectedDrink;
        public string SelectedDrink
        {
            get { return _selectedDrink; }
            set
            {
                _selectedDrink = value;
            }
        }
        private string _textBox1;
        public string TextBox1
        {
            get { return _textBox1; }
            set
            {
                _textBox1 = value;
            }
        }
        private int _textBox2;
        public int TextBox2
        {
            get { return _textBox2; }
            set
            {
                _textBox2 = value;
            }
        }
        public MainWindowViewModel()
        {
            IsFoodProperty = true;
            IsDrinkProperty = false;
            EnableProcessButton = new RelayCommand(() => ExecuteButton(null), () => CanExecuteButton(null));
        }
        public ICommand EnableProcessButton
        {
            get;
            internal set;
        }
        private bool CanExecuteButton(object obj)
        {
            switch (SelectedConMode)
            {
                case "Drinks":
                    return (!string.IsNullOrEmpty(SelectedDrink));
                case "Food":
                    return ((!string.IsNullOrEmpty(_textBox1)) && (_textBox2 != default(int)));
                default:
                    return false;
            }
        }
        private void ExecuteButton(object obj)
        {
            //DO the required things.
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
