    private void Test()
    {
        Person p1 = new Person(); // ok, this is clear, use ctor if possible, otherwise initobj
        Person p2 = default(Person); // use initobj
        Person p3 = CreateGeneric<Person>(); // and here?
        Person[] persons = new Person[100]; // do we have initialized persons?
    }
    public T CreateGeneric<T>() where T : new()
    {
        return new T();
    }
