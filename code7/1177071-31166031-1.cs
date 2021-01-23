    public class Adult : Person
    {
        public string DriversLicense { get; set; }
        public string StateIssued { get; set; }        
        public string AutoInsuranceCarrier { get; set; }
        public string PolicyNumer { get; set; }
    
        public string MaritalStatus { get; set; }
    
        //foreign key
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    
        public int AddressId {get; set;}
        public virtual Address Address { get; set; }
    }
