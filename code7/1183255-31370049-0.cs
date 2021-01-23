    // The entry containing the customer name
    private Entry _customerName;
    // Gets or sets the customer name
    public string Name
    {
        get
        {
            return this._customerName.Text;
        }
        set
        {
            this._customerName.Text = value;
        }
    }
