    private static DbSet<TEntity> SetUpFakeTable<TEntity>(params TEntity[] entities) where TEntity : class
    {
        var dataSource = entities.AsQueryable();
        var fakeDbSet = Substitute.For<DbSetWithFind<TEntity>, IQueryable<TEntity>>(dataSource); // changed type and added constructor params
        var fakeTable = (IQueryable<TEntity>) fakeDbSet;
        fakeTable.Provider.Returns(dataSource.Provider);
        fakeTable.Expression.Returns(dataSource.Expression);
        fakeTable.ElementType.Returns(dataSource.ElementType);
        fakeTable.GetEnumerator().Returns(dataSource.GetEnumerator());
            
        return (DbSet<TEntity>) fakeTable;
    }
