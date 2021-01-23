    [DataMember, BsonElement]
    public bool IsDeleted {
        get { return BackingDocument["IsDeleted", false]; }
        set { BackingDocument["IsDeleted"] = value; }
    }
