	public interface IEntity
	{
		int Id { get; set; }
	}
	public class Customer : IEntity
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime RegistrationDate { get; set; }
	}
	
	public interface IRepository<TEntity> where TEntity : class, IEntity
	{
		TEntity FindById(int id);
		
		void Add(TEntity entity);
		
		void Remove(TEntity entity);
	}
	
	public class CustomerRepository : IRepository<Customer>
	{
		public Customer FindById(int id)
		{
			// find the customer using their id
			return null;
		}
		
		public void Add(Customer customer)
		{
			// add the specified customer to the db
		}
		
		public void Remove(Customer customer)
		{
			// remove the specified customer from the db
		}
	}
