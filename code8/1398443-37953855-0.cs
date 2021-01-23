    var actual = scope.InstanceUnderTest.GetContent(expectedId);
    var type = actual.Result.GetType();
    var dataField = type.GetField("_data",
                         BindingFlags.NonPublic | 
                         BindingFlags.Instance);
    var contentTypeField = type.GetField("_contentType",
                         BindingFlags.NonPublic | 
                         BindingFlags.Instance);
    Assert.IsTrue(dataField.GetValue(actual.Result) == scope.TestDocument.Data);
    Assert.IsTrue(contentTypeField.GetValue(actual.Result) == "application/octet-stream");
