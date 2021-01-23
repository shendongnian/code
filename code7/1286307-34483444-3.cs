    public List<string> MembershipIds { get;set; }
    ...
    // This constructor will do the assignment.
    // If you do not plan to publish no-argument constructor,
    // it's OK to make it private.
    public MyClass() {
        MembershipIds = new List<string>();
    }
    // All other constructors will call the no-arg constructor
    public MyClass(int arg) : this() {// Call the no-arg constructor
        .. // do other things
    }
    public MyClass(string arg) : this() {// Call the no-arg constructor
        .. // do other things
    }
