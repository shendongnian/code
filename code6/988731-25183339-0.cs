	public Repository(IEntityService entityService)
	{
		_context = entityService.GetCustomerContext();
	}
	
	public partial class MyEntity : IMyContext
	{
		public MyEntity(string connectionString) : base(connectionString){}
	}
	
	public class EntityService : IEntityService
    {
        private readonly ISessionService _sessionService;
        public EntityService(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
		
		//This is only public because I need the connectionString to get a List of all the stored procs on the table.
        public string GetConnectionString()
        {
            var connectionString = "";
            CustomerConnection.GetCustomerConnection(_sessionService.GetCustomerId(), out connectionString);
            return connectionString;
        }
        public ICustomerContext GetCustomerContext()
        {
            return new MyEntity(connectionString.ToEntityConnectionString(typeof(MyEntity)));
        }
    }
	
