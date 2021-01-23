    private DbSet<T> ToDbSet<T>(List<T> sourceList) where T : class
    {
        var queryable = sourceList.AsQueryable();
        var dbSet = new Mock<DbSet<T>>();
        dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
        dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
        dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
        dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
        dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>(sourceList.Add);
        return dbSet.Object;
    }
    private void SomeOtherMethod() 
    {
        var journey = new Journey 
        { 
            SessionId = sessionId, 
            ConveyancingAnswer = new Collection<ConveyancingAnswer>()
        };
        var journeys = new List<Journey> { journey };  
        mockedDbContext.Setup(o => o.Journey)
                       .Returns(() => ToDbSet<Journey>(journeys));
    }
