    IContainer container = builder.Build();
    NoteBookContext noteBookContext = container.Resolve<DbContext>(
        new NamedParameter(
            "connectionstring", Consts.MyConnectionString
        )
    );
