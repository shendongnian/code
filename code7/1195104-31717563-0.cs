    private string _Text;
    public string Text
    {
        set
        {
            if (_Text != value)
            {
                _Text = value;
                RaisePropertyChanged(() => Text);
            }
        }
        get
        {
            return _Text;
        }
    }
