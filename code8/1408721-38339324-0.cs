    // required, should be called Id
    public string Id { get; set; }
    // optional. Using a Version field opts you into optimistic concurrency, where 
    // the server will reject updates that are done against an older version
    // of an object. This means you need a conflict handler.
    // To use a client-wins policy, remove this property from your client object
    [Version]
    public string Version { get; set; }
    // optional. Cannot be set on the client, will be sent from the server
    [CreatedAt]
    public DateTimeOffset CreatedAt { get; set; }
    // optional. Cannot be set on the client, will be sent from the server
    [UpdatedAt]
    public DateTimeOffset UpdatedAt { get; set; }
    // should generally not be used in the client object at all. This field tracks 
    // which objects have been deleted so that they are automatically purged
    // from the client's offline sync store
    [Deleted]
    public bool Deleted { get; set; }
