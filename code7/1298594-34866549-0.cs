    [DataContract]
    public class Customer
    {
        [DataMember(Name = "gors_descr")]
        public string ProductDescription { get; set; }
    
        [DataMember(Name = "b_name_first")]
        public string Fname { get; set; }
    
        [DataMember(Name = "b_name_last")]
        public string Lname { get; set; }
    }
