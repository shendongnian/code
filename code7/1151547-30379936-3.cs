    namespace MyCompany.MyProject.BusinessModels
    {
        [KnownType(typeof(Employee))]
        [DataContract]
        public class Report
        {
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public virtual Employee Manager { get; set; }
            [DataMember]
            public virtual Employee Employee { get; set; }
        }
    }
