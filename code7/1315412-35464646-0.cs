    [Test]
	public void q35387809() {
	    var backingStore = new Dictionary<string, string>();
	    var mockKvpRepository = new Mock<IKvpStoreRepository>();
		mockKvpRepository.SetupSet(x => x["blah"] = It.IsAny<string>())
			.Callback((string name, string value) => { backingStore[name] = value; });
		mockKvpRepository.Object["blah"] = "foo";
		backingStore.Count.Should().Be(1);
		backingStore["blah"].Should().Be("foo");
	}
