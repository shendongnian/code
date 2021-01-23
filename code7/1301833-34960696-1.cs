    public void Test()
    {
        var context = FakeContextBuilder.New()
                          .SetRequestMethod("POST")
                          .Build();
        ...
    }
