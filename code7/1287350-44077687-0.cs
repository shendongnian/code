    private static Mock<DbSet<T>> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
    {
      var elementsAsQueryable = elements.AsQueryable();
      var dbSetMock = new Mock<DbSet<T>>();
  
      dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
      dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
      dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
      dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());
      
      mockSet.Setup(t => t.Add(It.IsAny<T>())).Callback<T>(data.Add);
      mockSet.Setup(t => t.Remove(It.IsAny<T>())).Callback<T>(t => data.Remove(t));
      return dbSetMock;
    }
