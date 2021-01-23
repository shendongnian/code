    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IDNumber { get; set; }
        public double Total { get; set; }
        public Customer() { }
        public Customer(string aFirstName, string aLastName, int aIDNumber, double aTotal)
        {
            this.FirstName = aFirstName;
            this.LastName = aLastName;
            this.IDNumber = aIDNumber;
            this.Total = aTotal;
            Console.WriteLine(this.Display());
        }
        public string Display()
        {
            return String.Format(
				"Customer Created\r\n\tName: {0} {1}\r\n\tID: {2}\r\n\tBalance: {3}\r\n",
				this.FirstName, this.LastName, this.IDNumber, this.Total);
        }
	}
