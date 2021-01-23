    [Test]
    public void Can_Get_Forum_ById()
    {
        // arrange
        Forum dummyForum = new Forum { tblForumID = 1 };
        IQueryable<Forum> forums = new List<Forum> { dummyForum }.AsQueryable();
        Mock<ITable<Forum>> tableMock = new Mock<ITable<Forum>>();
        tableMock.Setup(p => p.GetEnumerator()).Returns(forums.GetEnumerator());
        tableMock.Setup(r => r.Provider).Returns(forums.Provider);
        tableMock.Setup(r => r.ElementType).Returns(forums.ElementType);
        tableMock.Setup(r => r.Expression).Returns(forums.Expression);
        Mock<IDataContextWrapper> mock = new Mock<IDataContextWrapper>();
        mock.Setup(m => m.GetTable<Forum>()).Returns(tableMock.Object);
        // act
        ForumRepository repos = new ForumRepository(mock.Object);
        Forum resultForum = repos.GetForumById(1);
        // assert
        Assert.AreEqual(resultForum.tblForumID, 1);
    }
