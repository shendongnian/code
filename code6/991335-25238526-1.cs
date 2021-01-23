    private bool comboEnabled = false;
    public bool ComboEnabled
    {
        get
        {
            return comboEnabled;
        }
        set
        {
            comboEnabled = value;
            onPropertyChanged("ComboEnabled");
        }
    }
    
    //and in your Server property
    public Server
    {
        get---YourCode{}
        set
        {
            if(value != null)
            ComboEnabled = true;
            ---Yourcode
        }
    }
    
    //and in your xaml
    <ComboBox Name="_computer" IsEnabled="{Binding ComboEnabled }"/>
