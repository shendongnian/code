    private string myField;
    public string MyField
    {
        get { return this.myField; }
        set { this.SetProperty(ref this.myField, value); }
    }
