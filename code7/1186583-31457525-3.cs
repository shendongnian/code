    //Method 1
    public string name { get; set; }
    //Method 2
    private string name; // this is private, not public.
    public string Name // this is a property, not a method.
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }
