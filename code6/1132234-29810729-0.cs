    virtual protected void parseData()
    {
        // iterate through the properties when it's called by a child class
        foreach(var p in this.GetType().GetProperties())
        {
            Console.WriteLine(p.Name);
            // and parse the strings for relevant data
        }
    }
