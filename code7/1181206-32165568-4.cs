    [TestMethod]
    public void CreateSearchResponse_RealObjectWithFakedDependencies()
    {
        var myClass = new MyClass();
        SearchResponse searchResponse = Isolate.Fake.Dependencies<SearchResponse>();
        Isolate.WhenCalled(() => myClass.GetSearchResponse()).WillReturn(searchResponse);
        SearchResponse sr = myClass.GetSearchResponse(); // returns SearchResponse
        //...
    }
