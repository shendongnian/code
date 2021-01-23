    void generateInstaces()
    {
        List<myClass> elements = new List<myClass>();
        for (int i = 0; i < 100; i ++)
            elements.Add(new myClass());
        foreach (myClass e in elements)
        {
            e.doSomething();
        }
    }
