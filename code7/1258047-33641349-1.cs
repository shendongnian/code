    public static class DbSetMocking
    {
        private static Mock<DbSet<T>> CreateMockSet<T>(IQueryable<T> data)
                where T : class
        {
            var queryableData = data.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider)
                    .Returns(queryableData.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression)
                    .Returns(queryableData.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType)
                    .Returns(queryableData.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator())
                    .Returns(queryableData.GetEnumerator());
            return mockSet;
        }
        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
                this IReturns<TContext, DbSet<TEntity>> setup,
                TEntity[] entities)
            where TEntity : class
            where TContext : DbContext
        {
            Mock<DbSet<TEntity>> mockSet;
            return ReturnsDbSet(setup, entities, out mockSet);
        }
        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
                this IReturns<TContext, DbSet<TEntity>> setup,
                IQueryable<TEntity> entities)
            where TEntity : class
            where TContext : DbContext
        {
            Mock<DbSet<TEntity>> mockSet;
            return ReturnsDbSet(setup, entities, out mockSet);
        }
        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
                this IReturns<TContext, DbSet<TEntity>> setup,
                IEnumerable<TEntity> entities)
            where TEntity : class
            where TContext : DbContext
        {
            Mock<DbSet<TEntity>> mockSet;
            return ReturnsDbSet(setup, entities, out mockSet);
        }
        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
        this IReturns<TContext, DbSet<TEntity>> setup,
        TEntity[] entities, out Mock<DbSet<TEntity>> mockSet)
            where TEntity : class
            where TContext : DbContext
        {
            mockSet = CreateMockSet(entities.AsQueryable());
            return setup.Returns(mockSet.Object);
        }
        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
                this IReturns<TContext, DbSet<TEntity>> setup,
                IQueryable<TEntity> entities, out Mock<DbSet<TEntity>> mockSet)
            where TEntity : class
            where TContext : DbContext
        {
            mockSet = CreateMockSet(entities);
            return setup.Returns(mockSet.Object);
        }
        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
        this IReturns<TContext, DbSet<TEntity>> setup,
        IEnumerable<TEntity> entities, out Mock<DbSet<TEntity>> mockSet)
            where TEntity : class
            where TContext : DbContext
        {
            mockSet = CreateMockSet(entities.AsQueryable());
            return setup.Returns(mockSet.Object);
        }
    }
