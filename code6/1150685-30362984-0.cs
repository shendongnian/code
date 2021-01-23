    [DataMember, BsonElement, BsonDefaultValue(false)]
    public bool IsDeleted {
        get { return BackingDocument["IsDeleted"].AsBoolean; }
        set { BackingDocument["IsDeleted"] = value; }
    }
