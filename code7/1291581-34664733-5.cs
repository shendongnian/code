    namespace Dashboard.Domain.Concrete
    {
        public class EFFlightRepository : IFlightRepository
        {
            private EFDbContext context;
    
            public IQueryable<Flight> Flights
            {
                get { return context.Flights;}
            }
    
            public EFFlightRepository(string connectionString)
            {
                context = new EFDbContext(connectionString);
            }
        }
    }
