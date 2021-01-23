    public interface IEntity
    {
        int Id { get; set; }
    }
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string custPhoneNumber { get; set; }
    }
