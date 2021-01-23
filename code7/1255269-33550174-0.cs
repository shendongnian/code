    public String Name { get; private set; }
    public Head Head { get; private set; }
    public Phrase? Complement { get; private set; }
    public Phrase(String Name, Head Head, Phrase? Complement)
    {
        this.Name = Name;
        this.Head = Head;
        this.Complement = Complement;
    }
