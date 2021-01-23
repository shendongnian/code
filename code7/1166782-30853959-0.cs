    using System.ComponentModel.DataAnnotations.Schema;
    [Table("List")]
    public class ListEntity
    {
        [Key]
        public int ID { get; set; }
        public string A { get; set; }
        public int B { get; set; }
        private string name;
        
        [NotMapped]
        public string C
        {
            get { return name; }
            set { name = value; }
        }
    }
