    class CustomerCreationResult {
        public Customer Customer() { get; set; }
        public CustomerCreationError Error() { get; set; }
    }
    
    class CustomerFactory {
        public CustomerCreationResult CreateCustomer(String name, int age) { ... }
    }
