    class CustomerResultModel{
        public Guid id {get;set;}
        public IEnumerable<ContactResultModel> Contacts {get;set;}
    }
    
    class ContactResultModel{
        public Guid id {get;set;}
        public Guid CustomerId {get;set;}
    }
