    class Contact{
        [Key]
        public int Id {get; set;}
        public string name {get; set;}
        public ICollection<Phone> phones{get; set;}
    }
    
    class Phone{
        [Key]
        public int id {get;set;}
        public string phone_type {get; set;}
        public string phone_number {get; set;}
        public Contact contact { get; set; }
    }
