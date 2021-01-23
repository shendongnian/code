    [TestMethod, Isolated]
    public void TestCount()
    {
        //Arrange
        int expSize = 5;
    
        var fakeClient = Isolate.Fake.AllInstances<CouchbaseClient>();
        var fakeIView = Isolate.Fake.AllInstances<IView>();
        var fakeIViewRow = Isolate.Fake.AllInstances<IViewRow>();
    
        LinkedList<IViewRow> resultList = new LinkedList<IViewRow>();
        for (int i = 0; i < expSize; i++)
             resultList.AddFirst(fakeIViewRow);
    
       Isolate.WhenCalled(() => fakeIView.TotalRows).WillReturn(expSize);
       Isolate.WhenCalled(() => fakeIView.GetEnumerator()).WillReturn(resultList.GetEnumerator());
       Isolate.WhenCalled(() => fakeClient.GetView("", "")).WillReturnCollectionValuesOf(fakeIView);
    
       //Act
       var target = new ClassUnderTest();
       var result = target.CountJsonDocs();
    
       //Assert
       Assert.AreEqual(expSize, result);
