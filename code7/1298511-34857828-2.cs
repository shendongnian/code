    private string firstName; // backing field
    public string FirstName
    {
        get
        {
            return this.firstName; // return the backing field
        }
        set
        {
            this.firstName = value; // set the backing field
        }
    }
