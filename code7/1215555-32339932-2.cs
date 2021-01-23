    public class ClientEmployees
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public static Func<Client, ClientEmployees> FromEntity = item => new ClientEmployees()
        {
            Id = item.Id,
            Name = item.Name,
            //map all fields
        };
    }
