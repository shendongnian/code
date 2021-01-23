    public B(A a)
    {
        var bType = this.GetType();
        // specify that we're only interested in public properties
        var aProps = a.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        // iterate through all the public properties in A
        foreach (var prop in aProps)
        {
            // for each A property, set the same B property to its value
            bType.GetProperty(prop.Name).SetValue(this, prop.GetValue(a));
        }
    }
