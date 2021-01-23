    [DataMember, BsonElement]
    public bool IsDeleted {
        get { return GetValue("IsDeleted", false); }
        set { SetValue("IsDeleted", value); }
    }
