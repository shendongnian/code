    public Employee this[string department]
    {
        get
        {
            return GetTheValue(department);
        }
    }
    ...
    var instance ..
    var employee = instance["Mid Level"]
