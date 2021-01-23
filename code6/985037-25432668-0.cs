    var fixture = new Fixture().Customize(new AutoConfiguredMoqCustomization());
    var dataReaderMock = fixture.Freeze<Mock<IDataReader>>();
    dataReaderMock.Setup(dr => dr.Read())
                  .Returns(true);
    //all pass
    Assert.Same(dataReaderMock.Object, fixture.Create<IDataReader>());
    Assert.Same(dataReaderMock.Object, fixture.Create<IDbCommand>().ExecuteReader());
    Assert.Same(dataReaderMock.Object, fixture.Create<IDbConnection>().CreateCommand().ExecuteReader());
    Assert.Same(dataReaderMock.Object, fixture.Create<Func<IDbConnection>>()().CreateCommand().ExecuteReader());
