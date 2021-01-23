    public class SalesPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<Client> Clients { get; set; }
    }
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }
        public int? SalesPersonId { get; set; }
    }
