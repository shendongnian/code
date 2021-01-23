    protected ClassRoom() : this(null)
    {
    }
    
    public ClassRoom(Person person)
        : this(person, person == null ? "" : person.Name)
    {
    }
    
    public ClassRoom(Person person, string name)
    {
        this.person = person;
        this.name = name;
    }
