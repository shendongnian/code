        private Mock<IPSNContext> BuildMockDbContext<T>(List<T> list)
        {
                    _mockDbSet = new Mock<DbSet<T>>();
                    _mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(list.AsQueryable().Provider);
                    _mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(list.AsQueryable().Expression);
                    _mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(list.AsQueryable().ElementType);
                    _mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(list.AsQueryable().GetEnumerator());
        
                    foreach (var item in list)            
                        _mockDbSet.Setup(m => m.Find(item.Id)).Returns(item);            
        
                    var mockContext = new Mock<IPSNContext>();
                    mockContext.Setup(c => c.Set<MessageBoardTopic>())
                                .Returns(_mockDbSet.Object);
        
                    return mockContext;
       }
