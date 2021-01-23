    class Account {
    public int ID { get; }
    public string Username { get; }
    [JsonIgnore]
    public string Password { get; }
    //... more properties
    }
