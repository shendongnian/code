    var generator = ((ISessionFactoryImplementor)Session.SessionFactory)
        .GetIdentifierGenerator(typeof(TEntity).FullName);
    if (generator is Assigned)
    {
        // Generate the identifier
    }
