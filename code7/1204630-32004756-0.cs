    private string _databaseAddress = "localHost";
    [Description("Example Description"), Category("CustomSettings"), DefaultValue("Transmedicom")]
    public string DatabaseAddress
    {
        get
        {
            return _databaseAddress;
        } 
        set 
        {
            if(!string.IsNullOrEmpty(value))
            {
                _databaseAddress = value;
                lblAddress.Text = value;
                lblAddress.Invalidate();
            }
        }
    }
