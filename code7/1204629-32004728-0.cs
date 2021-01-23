    private string databaseAddress;
    [Description("Example Description"), Category("CustomSettings"), DefaultValue("Transmedicom")]
    public string DatabaseAddress
    {
        get { return databaseAddress; }
        set 
        { 
            databaseAddress = value;
            yourLabel.Text = value;//Set value to Label or whatever
        }
    }
