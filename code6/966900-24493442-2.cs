    var dictionary = new Dictionary<string, object>();
    var mock = new Mock<ICache>(MockBehavior.Strict);
    mock.Setup(c => c.Set(It.IsAny<string>(), It.IsAny<object>()))
        .Callback((string k, object v) => dictionary[k] = v)
        .Returns((string k, object v) => v);
    mock.Setup(c => c.Get<object>(It.IsAny<string>()))
        .Returns((string k) => dictionary.ContainsKey(k) ? dictionary[k] : null);
    const string fooString = "foo";
    const string barString = "bar";
    mock.Object.Set(fooString, (object)barString);
    var bar = mock.Object.Get<object>(fooString);
    Assert.AreEqual(barString, bar);
