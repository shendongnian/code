    public void SO24740733_TestCustomValueHandler()
    {
        Dapper.SqlMapper.AddTypeHandler(RatingValueHandler.Default);
        var foo = connection.Query<MyResult>(
            "SELECT 'Foo' AS CategoryName, 200 AS CategoryRating").Single();
        foo.CategoryName.IsEqualTo("Foo");
        foo.CategoryRating.Value.IsEqualTo(200);
    }
    public void SO24740733_TestCustomValueSingleColumn()
    {
        Dapper.SqlMapper.AddTypeHandler(RatingValueHandler.Default);
        var foo = connection.Query<RatingValue>(
            "SELECT 200 AS CategoryRating").Single();
        foo.Value.IsEqualTo(200);
    }
