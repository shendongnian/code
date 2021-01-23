        public string testLabel
        {
            get { return _testLabel; }
            set
            {
                if (value != _testLabel)
                {
                    _testLabel = value;
                    OnPropertyChanged("testLabel"); // not testLabelChanged
                }
            }
        }
