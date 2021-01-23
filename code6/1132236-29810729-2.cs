    virtual protected void parseData()
    {
        // iterate through the properties when it's called by a child class
        foreach(var p in this.GetType().GetProperties())
        {
            // and parse the strings for relevant data
            var propName = p.Name;
            var propValue = p.GetValue(this);
            Console.WriteLine(string.Format("{0} = {1}", propName, propValue));
        }
    }
