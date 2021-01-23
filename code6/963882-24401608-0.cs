    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Customer()
        {
        }
        public void GetDetails()
        {
            Database db = new Database();
            return db.GetCustomer(this.Id).Details;
        }
    }
