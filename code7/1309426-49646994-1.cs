    const int ItemsCount = 1000;
    var dataReaderMock = new Mock<IDataReader>();
    var values = new object[ItemsCount, 2];
    for (var i = 0; i < ItemsCount; i++)
    {
        values[i, 0] = i + 1;
        values[i, 1] = (i + 1).ToString();
    }
    dataReaderMock.SetupDataReader(new List<string> {"Col1", "Col2"}, values);
