    [TestMethod]
    public void CreateSearchResponse_FakeObject_StateShouldBeSet_OriginalBehavior()
    {
        var myClass = new MyClass();
        SearchResponse fakeSearchResponse = Isolate.Fake.Instance<SearchResponse>(Members.CallOriginal, ConstructorWillBe.Called);
        Isolate.WhenCalled(() => myClass.GetSearchResponse()).WillReturn(fakeSearchResponse);
        SearchResponse sr = myClass.GetSearchResponse(); // returns fakeSearchResponse
        //...
    }
