    ISearchSchemaFactory factory = new MappingSearchSchemaFactory(
        new Dictionary<Type,ISearch<ISchema>>
        { new TableSchema(), new Table() },
        { new ViewSchema(), new view() }
    );
