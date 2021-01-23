    private string _myText;
        public string MyText
        {
            get { return _myText; }
            set
            {
                if (_myText != value)
                {
                    _myText = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(MyText)));
                }
            }
        }
