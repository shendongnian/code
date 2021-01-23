    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private IDatabase db { get; set; }
        public Customer(IDatabase db)
        {
            this.db = db;
        }
        public void GetDetails()
        {
            return db.GetCustomer(this.Id).Details;
        }
    }
