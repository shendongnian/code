    public Request()
    {
        Contacts = new List<Contact>();
    }
    public virtual ICollection<Contact> Contacts { get; set; }
