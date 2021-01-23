    string[] _text = new string[33];
    // repeat this 33 times
    public string Text1
    {
        get { return _text[0]; }
        set
        {
            _text[0] = value;
            OnPropertyChanged();
            SomeCommand.Update(); // evaluate CanExecute
        }
    }
    SomeCommand = new DelegateCommand( ... , !_text.Any(o => o.IsNullOrEmpty()));
