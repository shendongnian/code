    [Obsolete("This is for backward compatibility with existing database records. Use Names instead")]
    [DataMember(Name = "name")]
    public string Name
    {
        get
        {
            return Names.FirstOrDefault();
        }
        set
        {
            Names = new StringCollection();
            Names.Add(value);
        }
    }
