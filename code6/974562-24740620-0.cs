    public class StationRepository : GenericRepository<ShirazRailWay.ShirazRailwayEntities, DomainClass.Station>
    {
        public StationRepository(string connectionstring):base(connectionstring){}
    }
    
    public class GenericRepository<T1, T2>
    {
        protected GenericRepository(string connectionstring)
        {
            //initialize dbcontext using connection string
        }
    }
