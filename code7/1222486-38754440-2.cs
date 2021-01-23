    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Wepon> WeposInList { get; set; }
        [Column("Type")]
        public string TypeString
        {
           get { return Type.ToString(); }
           private set { Type= value.ParseEnum<Type>(); }
        }
 
        [NotMapped]
        public Type Type { get; set; }
    }  
