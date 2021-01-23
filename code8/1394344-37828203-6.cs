    public string GetHeader()
    {
        return Students.Aggregate("Class", (current, s) => current + "|" + s.Key);
    }
    public string GetSolidRow()
    {
        return Students.Aggregate(Class, (current, s) => current + "|" + s.Value);
    }
