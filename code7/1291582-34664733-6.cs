    namespace Dashboard.Domain.Factories
    {
        public interface IFlightRepoFactory
        {
            IFlightRepository CreateRepo(string connectionString);
        }
    }
