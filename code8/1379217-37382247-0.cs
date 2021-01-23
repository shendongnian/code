    Public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IDictionary<string, object> DynamicProperties { get; set; }
    }
