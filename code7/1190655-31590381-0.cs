     public string TextVariable {
            get 
            { return _TextVariable; }
            set 
            {
                _TextVariable = value; 
                NotifyPropertyChanged(); 
            } 
        }
