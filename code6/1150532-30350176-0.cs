    private readonly String name;
    public Person(string name)
    {
        if (string.IsNullOrEmpty(name)) // Or whatever
        {
            // Throw some exception
        }
        this.name = name;
    }
    // All the rest of the code can rely on name being a non-null 
    // reference to a non-empty string. Nothing can mutate it, leaving
    // evil reflection aside.
