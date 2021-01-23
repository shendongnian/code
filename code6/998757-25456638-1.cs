    [DataContract()]
    public class Student
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public String FirstName { get; set; }
        [DataMember]
        public String LastName { get; set; }
    }
    [DataContract()]
    public class StudentId
    {
        [DataMember]
        public Guid Id { get; set; }
    }
