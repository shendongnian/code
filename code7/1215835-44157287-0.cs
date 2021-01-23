    [DataContract]
    public class Foo
    {
    	[DataMember]
        public Id { get; set;}
    	
    	[DataMember(Name = "Jack"]
    	public string Bar { get; set;}
    	
    	[DataMember(Name = "Jane"]
    	public string Baz { get; set;}
        public int Fizz { get; set; }
        [NotMapped]
        public bool Buzz { get; set;
    }
