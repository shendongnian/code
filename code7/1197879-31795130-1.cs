    public Employee this[string department]
    {
        get
        {
            return GetTheValue(department);
        }
    }
    ...
    
    var instance = new Whatever();
    var employee = instance["Mid Level"]
