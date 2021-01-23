    using System.Runtime.Serialization;
    
    namespace APIValueSetterTest.Model
    {
        [DataContract]
        public class UserDetails
        {
            [DataMember]
            public int UserId { get; set; }
    		[DataMember]
            public string FullName { get; set; }
    		[DataMember]
            public string Username { get; set; }
    		[DataMember]
            public string ICEFullName { get; set; }
    		[DataMember]
            public int ICEMobileNumber { get; set; }
    		[DataMember]
            public string DoctorFullName { get; set; }
    		[DataMember]
            public int DoctorMobileNumber { get; set; }
        }
    }
