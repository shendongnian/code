    /// <summary>
    /// Provides structure for 'Student' entity
    /// </summary>
    /// 'DataContract' attribute is necessary to serialize object of following class. By removing 'DataContract' attribute, the following class 'Student' will no longer be serialized
    [DataContract]
    public class Student
    {
        [DataMember]
        public ushort Id { get; set; }
    
        [DataMember]
        public string UserName { get; set; }
    
        /// <summary>
        /// Password has been marked as non-serializable by removing 'DataContract'
        /// </summary>
        // [DataMember] // Password will not be serialized. Uncomment this line to serialize password
        public string Password { get; set; }
    
        [DataMember]
        public string FirstName { get; set; }
    
        [DataMember]
        public string LastName { get; set; }
            
        [DataMember]
        public List<Mark> Marks { get; set; }
    }
    
    [DataContract]
    public class Mark
    {
        [DataMember]
        public string Subject { get; set; }
    
        [DataMember]
        public short Percentage { get; set; }
    }
