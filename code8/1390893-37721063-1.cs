    [DataMember]
    public bool IsExpired
    {
        get
        {
            return DateTime.Now > this.ExpirationTime;
        }
        set
        {
            /* Dummy setter for serialization fix */
        }
    }
