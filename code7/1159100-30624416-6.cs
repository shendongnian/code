    public interface IEntity<out TEntitySchema>
        where TEntitySchema : EntitySchema
    {
        string Id { get; set; }
    }
    public class Contact : IEntity<ContactEntitySchema>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    // etc
