    Forum dummyForum = new Forum() { tblForumID = 1};
                Mock<ITable> tableMock = new Mock<ITable>();
                tableMock.Object.Attach(dummyForum);
                Mock<IDataContextWrapper> contextMock = new Mock<IDataContextWrapper>();
                contextMock .Setup(m => m.GetTable<Forum>()).Returns((ITable<Forum>)tableMock.Object) ;
    
                //act
                ForumRepository repos = new ForumRepository(mock.Object);
                Forum resultForum = repos.GetForumById(1);
    
                //assert
                Assert.AreEqual(resultForum.tblForumID, 1);
