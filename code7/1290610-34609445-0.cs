    [DataContract]
    public class Person
    {
        [DataMember] public string Name { get; set; }
        [DataMember] public long Size { get; set; }
        [DataMember] public DateTime Birthdate { get; set; }
    
        public Person(string name, long size, DateTime birthdate)
        {
            this.Name = name;
            this.Size = size;
            this.Birthdate = birthdate;
        }
    }
