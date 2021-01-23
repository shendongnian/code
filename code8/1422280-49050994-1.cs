    string _message;
    
    public string Message
    
            {
                get => _message;
                set
                {
                    _message = value;
                }
            }
    myEvent += () => Message = "New Value";
    
    <Label Text = "{Binding Message}"/>
