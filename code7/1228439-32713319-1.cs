    var queryable = session.Query<TestIndex.Result, TestIndex>()
                            .Customize(c =>
                            {
                                //do stuff
                            })
                            .As<Test>();
    var enumerator = session.Advanced.Stream(queryable);
    while (enumerator.MoveNext())
    {
        var entity = enumerator.Current.Document;
    }
