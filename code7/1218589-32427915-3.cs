    [DataContract(IsReference=true)]
    public class PERSON
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Genre Genre { get; set; }
        [DataMember]
        public List<PERSON> Parents { get; set; }
        [DataMember]
        public List<PERSON> Children { get; set; }
        public PERSON(string name, Genre genre)
        {
            this.Name = name;
            this.Genre = genre;
            Parents = new List<PERSON>();
            Children = new List<PERSON>();
        }
    }
