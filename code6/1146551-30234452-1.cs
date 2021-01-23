    public class Country
    {
        [Key]
        public int Sid { get; set; }
       
        [ForeignKey("ObjectIdInt")]
        public virtual ICollection<Heading> Headings { get; set; }
    
        ...
    }
    
    public class Heading
    {
        [Key]
        public int Id { get; set; }
    
        public string ObjectId { get; set; }
        public int ObjectIdInt 
        {
            get { return int.Parse(ObjectId); }
            set { ObjectId = value.ToString() }
        }
    }
