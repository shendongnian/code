    virtual protected void parseData()
    {
        var properties = this.GetType().GetProperties();
		
        // maintain the order
        Array.Sort(properties, comparer);
			
        // iterate through the properties when it's called by a child class
        foreach (var p in properties)
        {
            // and parse the strings for relevant data
            var propName = p.Name;
            var propValue = p.GetValue(this);
            Console.WriteLine(string.Format("{0} = {1}", propName, propValue));
        }
    }
