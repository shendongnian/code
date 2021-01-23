    public string Name
    {
        get;
        private set; //Making this private means you can still 
                        //access this setter within the class via `this.Name =`  (so be careful) 
    }
    /// <summary>
    /// Defined a public setter which can be invoked outside
    /// </summary>
    /// <param name="value"></param>
    public void SetName(string value)
    {
        if (value != null) //Check for null before validation (or it's up to you how to handle NULL value)
        {
            if (value.CompareTo("Admin") == 0 || value.CompareTo("Admin") == -1) //Just trying out comparison with the input.
            {
                Console.WriteLine("Invalid Name."); //To see if an invalid input that is not "Admin" fails.
            }
            else
            {
                Name = value;
                Console.WriteLine("Done.");
            }
        }
    }
    public Workers(string Name)
    {
        this.SetName(Name); //be careful making this.Name = Name or else no validation 
    }
    public Workers()
    {
        this.SetName(null); //be careful with this.Name = null or else no validation
    }
