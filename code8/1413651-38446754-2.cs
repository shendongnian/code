    [TestMethod]
    public void TestDynamicResults() {
        //Arrange
        var controller = new FooController();
        //Act
        var result = controller.GetAnonymousObject() as OkObjectResult;
        //Assert
        dynamic obj = new DynamicObjectResultValue(result.Value);
        Assert.IsNotNull(obj);
        Assert.AreEqual(1, obj.id);
        Assert.AreEqual("Foo", obj.name);
        Assert.AreEqual(3, obj.name.Length);
        Assert.AreEqual("Bar", obj.type);
    }
    [TestMethod]
    public void TestDynamicCollection() {
        //Arrange
        var controller = new FooController();
        //Act
        var result = controller.GetAnonymousCollection() as OkObjectResult;
        //Assert
        Assert.IsNotNull(result, "No ActionResult returned from action method.");
        dynamic jsonCollection = result.Value;
        foreach (dynamic value in jsonCollection) {
            dynamic json = new DynamicObjectResultValue(value);
            Assert.IsNotNull(json.id,
                "JSON record does not contain \"id\" required property.");
            Assert.IsNotNull(json.name,
                "JSON record does not contain \"name\" required property.");
            Assert.IsNotNull(json.type,
                "JSON record does not contain \"type\" required property.");
        }
    }
