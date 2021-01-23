    class BoardNote : NotificationObject
    {
    private string _text
    public string Text
    {
        get {return _text;}
        set 
        {
         if(_text == value) return;
         _text = value;
         RaisePropertyChanged(() => Text);
        }
    }
        public BoardNote(string text)
    {
        this.text = text;
    }
    public Visibility visibility
    {
        get
        {
            if (text.StartsWith("http"))
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }
    }
    }
