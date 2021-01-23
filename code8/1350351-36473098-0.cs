    public interface IRepository
    {
        bool IsTableOccupied(string tableId);
    }
    public class ExampleRepository : IRepository
    {
        public bool IsTableOccupied(string tableID)
        {
            // Your data access code goes here.
        }
    }
