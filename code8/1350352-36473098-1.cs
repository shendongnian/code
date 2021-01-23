    public class ExampleBusiness
    {
        private readonly IRepository repository;
        public ExampleBusiness(IRepository repository)
        {
            this.repository = repository;
        }
        public bool IsTableOccupied(string tableId)
        {
            return this.repository.IsTableOccupied(tableId);
        }
    }
