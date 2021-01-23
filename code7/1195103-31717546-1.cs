    private string _Text;
    public string Text
        {
            set 
            {
                _Text= value;
            }
            get 
            {
                return _Text;
                **OnPropertyChanged("Text");**
            }
        }
