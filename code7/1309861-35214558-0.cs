    using System.Runtime.Serialization;
    [DataContract]
    public class RealEstateVm
        {
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public string Title { get; set; }
            [DataMember]
            public string Description { get; set; }
            [DataMember]
            public int Area { get; set; }
            [DataMember]
            public int Rooms { get; set; }
            [DataMember]
            public int Rent { get; set; }
            [DataMember]
            public string Picture { get; set; }
            [DataMember]
            public RealEstateType Type { get; set; } //this is just an enum
            public string Address { get; set; }
            [DataMember]
            public List<string> Images { get; set; }
            public string Name { get; set; }
            [DataMember]
            public string Email { get; set; }
            [DataMember]
            public string Phone { get; set; }
            [DataMember]
            public string Phone2 { get; set; }
            [DataMember]
            public string OriginalUrl { get; set; }
            [DataMember]
            public string OriginalSource { get; set; }
            [DataMember]
            public string City { get; set; }
            [DataMember]
            public int ZipCode { get; set; }
            [DataMember]
            public string StreetAddress { get; set; }
            [DataMember]
            public double Longtitude { get; set; }
            [DataMember]
            public double Latitude { get; set; }
    }
