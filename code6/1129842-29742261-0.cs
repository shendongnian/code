    private string _emailMessage;
    public string emailMessage
    {
        get
        {
            return _emailMessage;
        }
        set
        {
            _emailMessage = value;
            OnPropertyChanged(emailMessage);
        }
