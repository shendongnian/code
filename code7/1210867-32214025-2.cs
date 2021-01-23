	public interface IUnitOfWork
	{
		IRepository<Dummy> Dummies { get; set; }
		IRepository<ProductType> ProductTypes { get; set; }
	}
