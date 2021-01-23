	public class Entity { }
	
	public interface IFinancialMarket { }
	
	public interface IFinancialMarketRepository<T> { }
	
	public class FinancialMarketRepository<TEntity> : IFinancialMarketRepository<TEntity>
		where TEntity : Entity, IFinancialMarket { }
