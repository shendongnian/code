    private string textA;
    public string TextA
    {
        get { return textA; }
        set
        {
            if (textA == value)
                return;
            textA = value;
            this.IsTextBoxBEnabled = String.IsNullOrEmpty(textA);
            OnPropertyChanged("TextA");
        }
    }
    private bool isTextBoxAEnabled;
    public bool IsTextBoxAEnabled
    {
        get { return isTextBoxAEnabled; }
        set
        {
            if (isTextBoxAEnabled == value)
                return;
            isTextBoxAEnabled = value;
            OnPropertyChanged("IsTextBoxAEnabled");
        }
    }
    
