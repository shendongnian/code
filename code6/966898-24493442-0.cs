	var dictionary = new Dictionary<string, object>();
	var mock = new Mock<ICache>(MockBehavior.Strict);
	mock.Setup(c => c.Set(It.IsAny<string>(), It.IsAny<object>))
		.Callback((k, v) => dictionary[k] = v);
	mock.Setup(c => c.Get(It.IsAny<string>())
		.Callback(k => return dictionary[k]);
