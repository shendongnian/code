    using (var session = NHibernateHelper<T>.OpenSession())
    {
        IList<Foo> foos = session.CreateCriteria<Foo>()
                ...
                .List<Contact>();
    }
    Foo foo = foos.First();
    // here we get merged instance with initiated
    foo =  foo.LoadCollection(f => f.SomeCollection);
