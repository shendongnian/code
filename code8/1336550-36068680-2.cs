    var artist = new Artist { Id = "4576" };
    var deserializer = Mock.Of<IXmlDeserializer<Album>>(d => d.Deserialize(It.Is<string>(i => i == "foo")) == Mock.Of<Album>(album => album.Artist == artist));
    Assert.IsNull(deserializer.Deserialize(null));
    Assert.IsNotNull(deserializer.Deserialize("foo"));
    Assert.AreEqual("4576", deserializer.Deserialize("foo").Artist.Id);
