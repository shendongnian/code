    public interface IRepositoryMockBuilder<TEntity> : IBuilder where TEntity : class
    {
    	List<TEntity> Entities { get; }
    
    	EntityState EntityState { get; }
    
    	Mock<IRepository<TEntity>> CreateMock();
    
    }
