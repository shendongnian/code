    //I don't think you need this line and if you need it the condition should have a !
    if (Database.Exists())
    {
        Database.Initialize(true);
    }
    //The constructor of DbContext can be empty, but it facilitates your work if you pass the connection string
    public InvitationContext() : base("YourConnectionString")
    //Use the anotation Key say to code-first migrations what is your, well, your key. Se set one key and then migrate your database.
    [Key]
    public int Key { get; set; }
