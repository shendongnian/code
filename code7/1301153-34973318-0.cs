    string s = null;
    var rows = session.QueryOver<Entity>()
        .Where(Expression.Eq(Projections.Property<Entity>(x => x.SomeField), s))
        .List();
                
