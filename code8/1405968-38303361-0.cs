    [TestMethod,Isolated]
    public void Isolate_OwinContext_Request_Query_Should_Be_Queryable()
    {
         // Arrange
        var key = Constants.AuthorizeRequest.ClientId;
        var collection = new Dictionary<string, string[]>() {
          {key, new[]{"1", "2", "3"} },
          {"B", new[]{"4", "5", "6"} }
        };
        
        // Can it be simpler than this?
        var fakeContext = Isolate.Fake.Instance<IOwinContext>();
        Isolate.WhenCalled(() => fakeContext.Request.Query).
            WillReturnCollectionValuesOf(collection.AsQueryable());
                       
        // Act
        var result = Program.SetUpQuery(fakeContext, null);
                         
        // Assert
        CollectionAssert.AreEquivalent(collection[key], result);
               
    }  
