    using System.Runtime.Serialization;
    namespace APIValueSetterTest.Model
      {
        [DataContract]
        public class RegisterModel
        {
            [DataMember]      
            public int UserId { get; set; }
            [DataMember]      
            public string Email { get; set; }
            [DataMember]
            public string Password { get; set; }
            [DataMember]
            public string ConfirmPassword { get; set; }
            [DataMember]
            public UserDetails UserDetails { get; set; }
        }
    
    }
