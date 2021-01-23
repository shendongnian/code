    private string message;
    public string Message
    {
        get
        {
            return message;
        }
        set
        {
            SetProperty(ref message, value.TrimEnd());
        }
