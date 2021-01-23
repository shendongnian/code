    public ChangeRequest(string title, string desc, TimeSpan jobLen,
                         int originalID)
    {
        // The following properties and the GetNexID method are inherited  
        // from WorkItem. 
        this.ID = GetNextID();
        ...
    }
