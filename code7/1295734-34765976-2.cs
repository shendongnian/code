    void generateInstaces()
    {
        List<myClass> elements = new List<myClass>();
        elements.Add(new myClass(1, "99a"));
        elements.Add(new myClass(17, "hta"));
        elements.Add(new myClass(9, "fff"));
        foreach (myClass e in elements)
        {
            e.doSomething();
        }
    }
