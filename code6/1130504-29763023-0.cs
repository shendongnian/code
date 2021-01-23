    public SomeClass()
    {
        a = new Apple(); // it is already assigned as null. 
        b = new Orange(a.getDna()); //there is no value assigned to it yet
        c = new Apple(b.getDna()); //it is already assigned as null
    }
