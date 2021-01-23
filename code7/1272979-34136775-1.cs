	public interface IRepository<T>
	{
		void Save(T model);
		void Submit(T model);
	}
	public class Order()
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public List<AbstractOrderline> OrderLines { get; set; }
		public IRepository<Order> Repository { get; set; }
		
		public void Save()
		{
			if (Repository == null) { throw new NotSupportedException(); }
			Repository.Save(this);
		}
		
		public void Submit()
		{
			if (Repository == null) { throw new NotSupportedException(); }
			Repository.Submit(this);
		}
	}
