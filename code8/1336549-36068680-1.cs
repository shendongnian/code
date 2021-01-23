    var artist = new Artist { Id = "4576" };
    var mock = new Mock<IXmlDeserializer<Album>>();
    mock.Setup(x => x.Deserialize(It.Is<string>(i => i == "foo"))).Returns(new Album() { Artist = artist });
    var deserializer = mock.Object;
    Assert.IsNull(deserializer.Deserialize(null));
    Assert.IsNotNull(deserializer.Deserialize("foo"));
