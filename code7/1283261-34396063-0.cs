       public Mock<DbSet<T>> GetMockDbSet<T>(string path) where T : class
            {
                var data = GetObjectList<T>(path).AsQueryable();
    
                var mockSet = new Mock<DbSet<T>>();
                mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
                mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
                mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
                mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(()=>data.GetEnumerator());
    
                mockSet.Setup(x => x.AsNoTracking()).Returns(mockSet.Object);
    
                return mockSet;
            }
