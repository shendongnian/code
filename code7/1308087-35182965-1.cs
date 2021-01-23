    var dbSetMock = new Mock<IDbSet<DbEntity>>();
    dbSetMock.Setup(m => m.Provider).Returns(data.Provider);
    dbSetMock.Setup(m => m.Expression).Returns(data.Expression);
    dbSetMock.Setup(m => m.ElementType).Returns(data.ElementType);
    dbSetMock.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
    
    var contextMock = new Mock<MyContext>();
    contextMock 
        .Setup(x => x.DbEntities)
        .Returns(dbSetMock.Object);
