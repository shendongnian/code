	public interface IEntity
	{
		int ID { get; set; }
	}
	public class Client : IEntity
	{
		public int ID { get; set; }
		public string Name { get; set; }		
	}
	public class Repository<T> 
		where T : IEntity
	{
		private readonly IQueryable<T> _collection;
		public Repository(IQueryable<T> collection)
		{
			_collection = collection;
		}
		
		public T FindByID(int id)
		{
			return _collection.First(e => e.ID == id);
		}
	}
