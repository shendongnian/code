    var queryResult = new List<int?>() { 0 };
    var fakeQueryResult = new ShimObjectResult<int?>
    {
        GetEnumerator = () => queryResult.GetEnumerator(),
        GetIListSourceListInternal = () => queryResult,
        GetEnumeratorInternal = () => queryResult.GetEnumerator()
    };
    mockContext.Setup(c => c.SP_DoSomething(param1, param2)).Returns(fakeQueryResult);
